import Docker from "dockerode";
import { ISocketRepository } from "../../Domain/Service/ISocket.repository";
import { DatabaseService } from "../Persistence/Database.service";

interface RoundActiveByUser {
  IdRonda: string;
  SubastaId: string;
  FechaCreacion: Date;
  Tiempo: number;
  FechaFinal: Date;
  IdItem: string;
  Nombre: string;
  Cantidad: number;
  UdmCode: string;
  oferta: number;
  Round: number;
}


interface GetActiveItemByUser {
  Cantidad: number,
  UnidadMedidaId: string,
  UdmCode: string,
  Nombre: string,
  ItemId: string,
  Oferta: number,
  respuesta: string,
  FechaCreacion: Date,
  UsuarioId: string,
  RondaId: string,
  Round: number,
  Tiempo: number,
}



export class RoundholandesaRepository {
  constructor(
    private readonly socketService: ISocketRepository,
    private readonly databaseService: DatabaseService
  ) { }

  public saveRoundHolandesa = async (body: any) => {
    try {
      const round = body.round;
      const haveRoundActive = await this.databaseService.haveRoundActive(
        round.auctionId,
        new Date()
      );
      console.log("datas",body.items);

      if (haveRoundActive) {
        return {
          status: 400,
          msg: "ya hay una ronda activa",
          data: {},
        };
      }
      const idround = await this.databaseService.saveRound({
        round: round.round,
        time: round.time,
        auctionId: round.auctionId
      });

      await this.databaseService.saveItemsRoundHolandesa(body.items, idround);
      await this.databaseService.saveUsers(body.providers, idround);

      
      this.socketService.notifyNextRound(round.auctionId, body.providers);
      return {
        status: 200,
        msg: "Ronda creada correctamente",
        data: {},
      };
    } catch (error) {
      console.log(error);
      return {
        status: 500,
        msg: "Error al guardar la respuesta",
        data: {},
      };
    }
  };

  public getRoundActiveHolandesa = async (auctionId: string, userId: string|null) => {
    try {
      const now: any = new Date();
      let userIsVoted:any ="";
      const round: RoundActiveByUser[] =
        await this.databaseService.getRoundActiveByUserHolandesa(auctionId, userId);
      if (round.length === 0) {
        return {
          status: 400,
          msg: "No hay ronda activa",
          data: {},
        };
      }
      const fechaFinal: any = new Date(round[0].FechaFinal);
      const remainingTimeMs = fechaFinal - now;

      const hours = Math.floor((remainingTimeMs / (1000 * 60 * 60)) % 24);
      const minutes = Math.floor((remainingTimeMs / (1000 * 60)) % 60);
      const seconds = Math.floor((remainingTimeMs / 1000) % 60);

       console.log(round[0],"ronda");
      const tiempoRestante = `${String(hours).padStart(2, "0")}:${String(
        minutes
      ).padStart(2, "0")}:${String(seconds).padStart(2, "0")}`;
      if(userId != null)
      {
        userIsVoted = await this.databaseService.userIsVoted(
          round[0].IdRonda,
          userId ?? ""
        );
      }
      const dataRound = {
        IdRonda: round[0].IdRonda,
        SubastaId: round[0].SubastaId,
        FechaCreacion: round[0].FechaCreacion,
        Tiempo: round[0].Tiempo,
        FechaFinal: round[0].FechaFinal,
        TiempoRestante: tiempoRestante,
        UserIsVoted: userIsVoted?? "",
        Items: round.map((item: RoundActiveByUser) => ({
          ItemId: item.IdItem,
          Nombre: item.Nombre,
          Cantidad: item.Cantidad,
          UdmCode: item.UdmCode,
          oferta: item.oferta,
          Round: item.Round,
        })),
      };
      return {
        status: 200,
        msg: "",
        data: dataRound,
      };
    } catch (error) {
      console.log(error);
      return {
        status: 500,
        msg: "Error al obtener la ronda",
        data: {},
      };
    }
  };

  public saveResponseRoundHolandesa = async (body: any) => {
    try {
      await this.databaseService.saveResponseRoundHolandesa(body.items);
      const roundId = body.items[0].roundId;
      const dataSend = body.items.map((item: any) => ({
        itemId: item.itemId,
        name: item.item,
        quantity: item.quantity,
        offer: item.offer,
        response: item.response,
      }));
      this.socketService.notifyResumeRoundByUser(body.items[0].userId, {
        roundId,
        items: dataSend,
      });
      console.log("subasta",body.idSubasta)
      this.socketService.notifyResumeRoundByProvider(body.idSubasta,dataSend)
      return {
        status: 200,
        msg: "Respuesta guardada correctamente",
        data: {},
      };
    } catch (error) {
      console.log(error);
      return {
        status: 500,
        msg: "Error al guardar la respuesta",
        data: {},
      };
    }
  };

  public getResponseItemByUserHolandesa = async (body: any) => {
    try {
      const responseResumen = await this.databaseService.getResponseItemByUserHolandesa(
        body.auctionId,
        body.userId,
        body.filterGranted
      );

      // Agrupar por RondaId y asociar los Items correspondientes
      const groupedData = responseResumen.reduce((acc: any, item: any) => {
        const roundKey = item.RondaId;  // Usamos el RondaId como clave para agrupar
        if (!acc[roundKey]) {
          acc[roundKey] = {
            RondaId: item.RondaId,
            UsuarioId: item.UsuarioId,
            Round: item.Round,
            Tiempo: item.Tiempo,
            Items: []
          };
        }
        // Añadir el item a la ronda correspondiente
        acc[roundKey].Items.push({
          Cantidad: item.Cantidad,
          UnidadMedidaId: item.UnidadMedidaId,
          UdmCode: item.UdmCode,
          Nombre: item.Nombre,
          ItemId: item.ItemId,
          Oferta: item.Oferta,
          Respuesta: item.Respuesta,
          FechaCreacion: item.FechaCreacion,
          respuesta: item.respuesta
        });
        return acc;
      }, {});

      // Convertimos el objeto agrupado en un array para que sea más fácil de manejar
      const finalData = Object.values(groupedData);


      if (responseResumen.length === 0) {
        return {
          status: 400,
          msg: "No hay rondas",
          data: {},
        };
      }

      return {
        status: 200,
        msg: "",
        data: finalData,
      };
    } catch (error) {
      console.log(error);
      return {
        status: 500,
        msg: "Error al obtener la ronda",
        data: {},
      };
    }
  };


  public getResponseItemProviderHolandesa = async (body: any) => {
    try {
      const responseResumen = await this.databaseService.getResponseItemProviderHolandesa(
        body.auctionId,
        body.filterGranted
      );

      // Agrupar por RondaId y asociar los Items correspondientes
      const groupedData = responseResumen.reduce((acc: any, item: any) => {
        const roundKey = item.RondaId; // Clave de agrupación
    
        if (!acc[roundKey]) {
            acc[roundKey] = {
                RondaId: item.RondaId,
                Round: item.Round,
                proveedores: [], // Lista de proveedores
            };
        }
    
        // Buscar si el proveedor ya existe en la ronda
        let proveedor = acc[roundKey].proveedores.find((p: any) => p.IdProveedor === item.IdProveedor);
    
        if (!proveedor) {
            // Si el proveedor no existe, lo creamos
            proveedor = {
                IdProveedor: item.IdProveedor,
                Nombre: item.NombreEmpresa,
                Items: [] // Lista de items específicos del proveedor
            };
            acc[roundKey].proveedores.push(proveedor);
        }
    
        // Agregar el item a la lista de Items del proveedor correspondiente
        proveedor.Items.push({
            Cantidad: item.Cantidad,
            UnidadMedidaId: item.UnidadMedidaId,
            UdmCode: item.UdmCode,
            Nombre: item.Nombre,
            ItemId: item.ItemId,
            Oferta: item.Oferta,
            Respuesta: item.Respuesta,
            FechaCreacion: item.FechaCreacion,
            respuesta: item.respuesta
        });
    
        return acc;
    }, {});

      // Convertimos el objeto agrupado en un array para que sea más fácil de manejar
      const finalData = Object.values(groupedData);


      if (responseResumen.length === 0) {
        return {
          status: 400,
          msg: "No hay rondas",
          data: {},
        };
      }

      return {
        status: 200,
        msg: "",
        data: finalData,
      };
    } catch (error) {
      console.log(error);
      return {
        status: 500,
        msg: "Error al obtener la ronda",
        data: {},
      };
    }
  };


  public getLatestRoundHolandesa = async (body: any) => {
    try {
      const responseResumen = await this.databaseService.getLatestRoundHolandesa(
        body.auctionId
      );

      // Agrupar por RondaId y asociar los Items correspondientes
      const groupedData = responseResumen.reduce((acc: any, item: any) => {
        const roundKey = item.RondaId;  // Usamos el RondaId como clave para agrupar
        if (!acc[roundKey]) {
          acc[roundKey] = {
            RondaId: item.RondaId,
            UsuarioId: item.UsuarioId,
            FechaCreacion: item.FechaCreacion,
            Round: item.Round,
            Tiempo: item.Tiempo,
            Items: []
          };
        }
        // Añadir el item a la ronda correspondiente
        acc[roundKey].Items.push({
          Cantidad: item.Cantidad,
          ValorUnidad: item.ValorUnidad,
          UdmCode: item.UdmCode,
          Nombre: item.Nombre,
          ItemId: item.ItemId,
          Oferta: item.Oferta,
          ValorInicial: item.valorInicial,
          DescuentoAumento: item.DescuentoAumento,
          LimiteOferta: item.LimiteOferta
        });
        return acc;
      }, {});

      // Convertimos el objeto agrupado en un array para que sea más fácil de manejar
      const finalData = Object.values(groupedData);


      if (responseResumen.length === 0) {
        return {
          status: 400,
          msg: "No hay rondas",
          data: {},
        };
      }

      return {
        status: 200,
        msg: "",
        data: finalData,
      };
    } catch (error) {
      console.log(error);
      return {
        status: 500,
        msg: "Error al obtener la ronda",
        data: {},
      };
    }
  };

  public saveResponseOtorgarJaponesa = async (body: any) => {
    try {
      await this.databaseService.saveResponseOtorgarJaponesa(body);
      const responseResumen = await this.databaseService.POSTUCTIONGRANTITEMBYUSERJAPONESA(body.IdItem,body.IdRonda,body.IdUsuario)
      const dataSendResumen = responseResumen.map((item: any) => ({
        ItemId: item.ItemId,
        Proveedor: item.NombreEmpresa,
        Nombre: item.Nombre,
        Cantidad: item.Cantidad,
        Oferta: item.NuevaOferta,
        IdProveedor:item.IdProveedor
      }));
      console.log(dataSendResumen[0])
      this.socketService.notifyResponseAwarded(body.IdSubasta,dataSendResumen[0])
      return {
        status: 200,
        msg: "Respuesta Actualizada correctamente",
        data: {},
      };
    } catch (error) {
      console.log(error);
      return {
        status: 500,
        msg: "Error al guardar la respuesta",
        data: {},
      };
    }
  };

}
