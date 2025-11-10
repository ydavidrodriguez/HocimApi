import { Server } from "socket.io";

export interface ISocketRepository {
  initialize(io: Server): void;
  notifyNextRound(auctionId: string, users_notify: any[]): void;
  notifyResumeRoundByUser(userId: string, data: any): void;
  notifyAlertByUser(userId: string, data: any): void;
  notifyResumeRoundByProvider(auctionId: string, data: any):void;
  notifyResponseAwarded(auctionId: string, data:any): void;
  notifyResponseAddTime(auctionId:string,data:any):void;
  notifyResponseCreatOftter(auctionId:string,data:any):void;
  notifyPasueAuction(auctionId:string,data:any):void;
  notifyEndAuction(auctionId:string,data:any):void;
  EndAuction(auctionId: string):void;

}
