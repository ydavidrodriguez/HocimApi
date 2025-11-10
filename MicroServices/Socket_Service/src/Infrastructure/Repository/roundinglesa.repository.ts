import {makeRequest } from "../../External/Service/SendHttpRespository";
import { ISocketRepository } from "../../Domain/Service/ISocket.repository";

export class RoundInglesaRepository {
  constructor(
    private readonly socketService: ISocketRepository,
    private readonly urlTime: string,
    private readonly urlOfter: string,
    private readonly urlSuspender: string,
    private readonly urlreanudar: string,
    private readonly urlEnd: string
  ) {
    console.log(urlTime)
  }

  public TimeRound = async (body: any) => {
    try {
      const round = body;
   
      const data = {
        idSubasta:body.idSubasta,
        minutos:body.minutos,
        usuarioId:body.usuarioId
      };
  
      const response = await makeRequest('PUT', this.urlTime, data,{
        'Content-Type': 'application/json' 
      });

      try {
            console.log('Intentando ejecutar notifyResponseAddTime...');
            this.socketService.notifyResponseAddTime(round.idSubasta, round.Minutos);
            console.log('notifyResponseAddTime ejecutado correctamente');
        } catch (error) {
           console.error('Error al ejecutar notifyResponseAddTime:', error);
        }

      return response;
 
    } catch (error) {
      console.log(error);
      return {
        status: 500,
        msg: "Error al guardar la respuesta" + error,
        data: {},
      };
    }
  };

  public CreateOffer = async (body: any) => {
    try {
      const round = body;
   
      const data = {
        subastaId:body.subastaId,
        itemId:body.itemId,
        valorOferta:body.valorOferta,
        usuarioId:body.usuarioId,
        proveedorId:body.proveedorId
      };
  
      const response = await makeRequest('POST', this.urlOfter, data,{
        'Content-Type': 'application/json' 
      });

      this.socketService.notifyResponseCreatOftter(round.subastaId, data);
      return response;
 
    } catch (error) {
      console.log(error);
      return {
        status: 500,
        msg: "Error al guardar la respuesta" + error,
        data: {},
      };
    }
  }

  public SuspendAuctionInglesa = async (body: any) => {
    try {
      const round = body;
      
      console.log("Body",body);

      const data = {
        subastaId:body.idSubasta,
        fechaDetencion:body.fechaDetencion,
        fechaReanudacion:body.fechaReanudacion
      };
  
      const response = await makeRequest('PUT', this.urlSuspender, data,{
        'Content-Type': 'application/json' 
      });

      this.socketService.notifyPasueAuction(body.idSubasta, data);
      return response;
 
    } catch (error) {
      console.log(error);
      return {
        status: 500,
        msg: "Error al guardar la respuesta" + error,
        data: {},
      };
    }
  }

  
  public ActivateAuctionInglesa = async (body: any) => {
    try {
      const round = body;
   
      const data = {
        subastaId:body.subastaId,
        fechaDetencion:body.fechaDetencion,
        fechaReanudacion:body.fechaReanudacion
      };
  
      const response = await makeRequest('PUT', this.urlreanudar, data,{
        'Content-Type': 'application/json' 
      });

      this.socketService.notifyPasueAuction(body.subastaId, response.data);
      return response;
 
    } catch (error) {
      console.log(error);
      return {
        status: 500,
        msg: "Error al guardar la respuesta" + error,
        data: {},
      };
    }
  }

  public EndAuction = async (body: any) => {
    try {
      const round = body;
   
      const data = {
        UsuarioId:body.usuarioId,
        SubastaId:body.subastaId,
        EstadoId:body.estadoId
      };

      const response = await makeRequest('PUT', this.urlEnd, data,{
        'Content-Type': 'application/json' 
      });
      this.socketService.notifyEndAuction(round.subastaId, response.data);
      this.socketService.EndAuction(round.subastaId);
      return response;
 
    } catch (error) {
      console.log(error);
      return {
        status: 500,
        msg: "Error al guardar la respuesta" + error,
        data: {},
      };
    }
  }


  


}