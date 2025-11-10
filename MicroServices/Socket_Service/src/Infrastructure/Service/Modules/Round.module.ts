import { Server } from "socket.io";

export class RoundModule {
  constructor() {}

  public notifyNextRound(
    io: Server,
    auctionId: string,
    users_notify: any[]
  ): void {
    io.to(auctionId).emit("next_round");
    users_notify.forEach((user) => {
      io.to(user.usuarioId).emit("next_round_by_user");
    });
  }
}
