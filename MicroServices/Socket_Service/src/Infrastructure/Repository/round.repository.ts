import Docker from "dockerode";
import { ISocketRepository } from "../../Domain/Service/ISocket.repository";
import { DatabaseService } from "../Persistence/Database.service";

interface RoundActiveByUser {
  IdRonda: string;
  SubastaId: string;
  FechaCreacion: Date;
  Tiempo: number;
  FechaFinal: Date;
  IdItemsRonda: string;
  Nombre: string;
  Cantidad: number;
  NuevaOferta: number;
  ItemId: string;
}

export class RoundRepository {
  constructor(
    private readonly socketService: ISocketRepository,
    private readonly databaseService: DatabaseService
  ) {}

  public goToNextRound = async (body: any) => {
    try {
      const round = body.round;
      const haveRoundActive = await this.databaseService.haveRoundActive(
        round.auctionId,
        new Date()
      );
      if (haveRoundActive) {
        return {
          status: 400,
          msg: "Ya hay una ronda activa",
          data: {},
        };
      }
      const idRound = await this.databaseService.saveRound({
        round: round.round,
        time: round.time,
        auctionId: round.auctionId,
      });
      console.log(idRound);

      await this.databaseService.saveItems(body.items, idRound);
      await this.databaseService.saveUsers(body.providers, idRound);
      this.socketService.notifyNextRound(round.auctionId, body.providers);
      return {
        status: 200,
        msg: "Ronda creada correctamente",
        data: {},
      };
    } catch (error) {
      return {
        status: 500,
        msg: "Error al crear la ronda",
        data: {},
      };
    }
  };

  public getRoundActive = async (auctionId: string) => {
    try {
      const now: any = new Date();
      const round = await this.databaseService.getRoundActive(auctionId, now);
      if (!round) {
        return {
          status: 400,
          msg: "No hay ronda activa",
          data: {},
        };
      }
      const fechaFinal: any = new Date(round.FechaFinal);
      const remainingTimeMs = fechaFinal - now;

      const hours = Math.floor((remainingTimeMs / (1000 * 60 * 60)) % 24);
      const minutes = Math.floor((remainingTimeMs / (1000 * 60)) % 60);
      const seconds = Math.floor((remainingTimeMs / 1000) % 60);

      const tiempoRestante = `${String(hours).padStart(2, "0")}:${String(
        minutes
      ).padStart(2, "0")}:${String(seconds).padStart(2, "0")}`;
      return {
        status: 200,
        msg: "",
        data: {
          IdRonda: round.IdRonda,
          SubastaId: round.SubastaId,
          FechaCreacion: round.FechaCreacion,
          Tiempo: round.Tiempo,
          Round: round.ROUND,
          TiempoRestante: tiempoRestante,
        },
      };
    } catch (error) {
      console.log(error);
      return {
        status: 500,
        msg: "Error al obtener la ronda activa",
        data: {},
      };
    }
  };

  public getLatestRound = async (auctionId: string) => {
    try {
      const rounds = await this.databaseService.getLatestRound(auctionId);
      if (rounds.length === 0) {
        return {
          status: 400,
          msg: "No hay rondas",
          data: {},
        };
      }
      const items = rounds
        .filter((row: any) => row.IdItemsRonda) // Filtrar filas con ítems
        .map((row: any) => ({
          IdItemsRonda: row.IdItemsRonda,
          ItemId: row.ItemId,
          Nombre: row.Nombre,
          Cantidad: row.Cantidad,
          valorUnidad: row.valorUnidad,
          NuevaOferta: row.NuevaOferta,
        }));
      const rondaConItems = {
        IdRonda: rounds[0].IdRonda,
        SubastaId: rounds[0].SubastaId,
        FechaCreacion: rounds[0].FechaCreacion,
        Tiempo: rounds[0].Tiempo,
        Round: rounds[0].Round,
        Items: items,
      };
      return {
        status: 200,
        msg: "",
        data: rondaConItems,
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

  public getRoundActiveByUser = async (auctionId: string, userId: string) => {
    try {
      const now: any = new Date();
      const round: RoundActiveByUser[] =
        await this.databaseService.getRoundActiveByUser(auctionId, userId, now);
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

      const tiempoRestante = `${String(hours).padStart(2, "0")}:${String(
        minutes
      ).padStart(2, "0")}:${String(seconds).padStart(2, "0")}`;

      const userIsVoted = await this.databaseService.userIsVoted(
        round[0].IdRonda,
        userId
      );
      const dataRound = {
        IdRonda: round[0].IdRonda,
        SubastaId: round[0].SubastaId,
        FechaCreacion: round[0].FechaCreacion,
        Tiempo: round[0].Tiempo,
        FechaFinal: round[0].FechaFinal,
        TiempoRestante: tiempoRestante,
        UserIsVoted: userIsVoted,
        Items: round.map((item: RoundActiveByUser) => ({
          IdItemsRonda: item.IdItemsRonda,
          ItemId: item.ItemId,
          Nombre: item.Nombre,
          Cantidad: item.Cantidad,
          NuevaOferta: item.NuevaOferta,
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

  public validateSaveResponseRound = async(auctionId: string, totalItems: number )=>{
    try{
      const totalStored = await this.databaseService.getItemsCountByAuction(auctionId);
      
      if(totalItems < totalStored){
        return{
          status: 400,
          msg: "La cantidad de items aprobados y/o rechazados es menor a la cantidad de items de la subasta",
          data:{state: false}
        };
      }

      else{
        return{
          status: 200,
          msg: "La cantidad de items es correcta",
          data: {state: true}
        }
      }

    }catch (error) {
      console.log(error);
      return {
        status: 500,
        msg: "Error al validar la cantidad de items",
        data: {},
      };
    }
  }

  public saveResponseRound = async (body: any) => {
    try {
      await this.databaseService.saveResponseRound(body.items);
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

  public getResumeRoundByUser = async (body: any) => {
    try {
      const responseResumen = await this.databaseService.getResponseByUser(
        body.userId,
        body.auctionId
      );

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
        data: this.formatData(responseResumen),
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

  

  private formatData(data: any) {
    // Agrupamos los datos por `RondaId`
    const groupedByRound = data.reduce((acc: any, item: any) => {
      const roundId = item.RondaId;

      if (!acc[roundId]) {
        acc[roundId] = [];
      }

      // Verificamos si el itemId ya existe en los items de esta ronda
      const isDuplicate = acc[roundId].some(
        (existingItem: any) => existingItem.itemId === item.IdItemsRonda
      );

      if (!isDuplicate) {
        acc[roundId].push({
          itemId: item.IdItemsRonda,
          name: item.Nombre,
          quantity: item.Cantidad,
          offer: item.NuevaOferta,
          response: item.respuesta,
        });
      }

      return acc;
    }, {});

    // Transformamos el objeto agrupado en un array
    return Object.entries(groupedByRound).map(([roundId, items]) => ({
      roundId,
      items,
    }));
  }

  public getResponseItemProviderJaponesa = async (body: any) => {
    try {
      const responseResumen = await this.databaseService.getResponseItemProviderJaponesa(
        body.auctionId,
        body.filterGranted
      );

      console.log("r",responseResumen)
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
                IdUsuario: item.IdUsuario,
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
            Oferta: item.NuevaOferta,
            FechaCreacion: item.FechaCreacion,
            respuesta: item.respuesta,
            IdGanadorSubasta: item.IdGanadorSubasta || null
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
  
}
