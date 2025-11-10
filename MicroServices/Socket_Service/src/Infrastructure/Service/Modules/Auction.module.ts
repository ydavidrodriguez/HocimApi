import { Server } from "socket.io";

export default class AuctionModule {
  constructor() {}

  public notifyAuctionChange(io: Server, auctionId: string, data: any): void {
    io.to(auctionId).emit("auction_change", data);
  }

  public notifyAuctionOfferChange(io: Server, auctionId: string, data: any): void {
    io.to(auctionId).emit("auction_change_offer", data);
  }

  public notifyUsersOfAuctionChange(
    io: Server,
    users: string[],
    data: any
  ): void {
    users.forEach((userId) => {
      io.to(userId).emit("auction_change_user", data);
    });
  }
}
