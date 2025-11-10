import { Server, Socket } from "socket.io";

export default class ResumensModule {
  constructor() {}

  public notifyResumeRoundByUser(io: Server, userId: string, data: any): void {
    io.to(userId).emit("resume_round_by_user", data);
  }

  public notifyResumeRoundByProvider(io: Server, auctionId: string, data: any): void {
    io.to(auctionId).emit("resume_round_by_provider", data);
  }

  public notifyAlertByUser(socket: Socket, userId: string, data: any): void {
    socket.to(userId).emit("alert_by_user", data);
  }

  public notifyResponseAwarded(io: Server, auctionId: string, data: any): void {
    io.to(auctionId).emit("response_Awarded_by_provider", data);
  }
  public notifyResponseAddTime(io:Server,auctionId:string,data:any):void{
    io.to(auctionId).emit("response_AddTime_by_provider",data)
  }
  public notifyResponseCreateOffer(io:Server,auctionId:string,data:any):void{
    io.to(auctionId).emit("response_CreateOffer_by_provider",data)
  }
  public notifyPasueAuction(io:Server,auctionId:string,data:any):void{
    io.to(auctionId).emit("response_notifyPasueAuctio_by_provider",data)
  }
  public notifyEndAuction(io:Server,auctionId:string,data:any):void{
    io.to(auctionId).emit("response_notifyEndAuction_by_provider",data)
  }

}
