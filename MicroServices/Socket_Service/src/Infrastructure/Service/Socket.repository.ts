import ChatModule from "./Modules/Chat.module";
import fastifySocketIO from "fastify-socket.io";
import { Server, Socket } from "socket.io";
import { ISocketRepository } from "../../Domain/Service/ISocket.repository";
import { RoundModule } from "./Modules/Round.module";
import ResumensModule from "./Modules/Resumens.module";
import AuctionModule from "./Modules/Auction.module";

export default class SocketRepository implements ISocketRepository {
  private io: Server = new Server();
  private chatModule: ChatModule;
  private roundModule: RoundModule;
  private resumensModule: ResumensModule;
  private auctionModule: AuctionModule;

  constructor(
    app: any,
    chatModule: ChatModule,
    roundModule: RoundModule,
    resumensModule: ResumensModule,
    auctionModule: AuctionModule
  ) {
    this.chatModule = chatModule;
    this.roundModule = roundModule;
    this.resumensModule = resumensModule;
    this.auctionModule = auctionModule;
    app.register(fastifySocketIO, {
      cors: {
        origin: "*",
        methods: ["GET", "POST"],
        allowedHeaders: ["Content-Type"],
        credentials: true,
      },
      transports: ["polling", "websocket"],
      path: "/ws",
      allowEIO3: true,
      pingInterval: 25000,
      pingTimeout: 60000,
    });
  }
  notifyAlertByUser(auctionId: string, data: any): void {
    // this.resumensModule.notifyAlertByUser(this.io, auctionId, data);
  }
  notifyResumeRoundByUser(userId: string, data: any): void {
    this.resumensModule.notifyResumeRoundByUser(this.io, userId, data);
  }
  notifyResumeRoundByProvider(auctionId: string, data: any): void {
    this.resumensModule.notifyResumeRoundByProvider(this.io,auctionId,data);
  }
  notifyNextRound(auctionId: string, users_notify: any[]): void {
    this.roundModule.notifyNextRound(this.io, auctionId, users_notify);
  }
  notifyResponseAwarded(auctionId: string, data:any): void {
    this.resumensModule.notifyResponseAwarded(this.io, auctionId, data);
  }
  notifyResponseAddTime(auctionId:string,data:any):void{
    this.resumensModule.notifyResponseAddTime(this.io,auctionId,data);
  }
  notifyResponseCreatOftter(auctionId:string,data:any):void{
    this.resumensModule.notifyResponseCreateOffer(this.io,auctionId,data);
  }
  notifyPasueAuction(auctionId:string,data:any):void{
    this.resumensModule.notifyPasueAuction(this.io,auctionId,data);
  }
  notifyEndAuction(auctionId:string,data:any):void{
    this.resumensModule.notifyEndAuction(this.io,auctionId,data);
  }
  EndAuction(auctionId: string): void {
    // Desconectar solo los usuarios en la sala de la subasta
    this.io.in(auctionId).disconnectSockets();
  }

  public initialize = (io: Server): void => {
    this.io = io;
    // Evento de conexión
    this.io.on("connection", (socket: Socket) => {
      console.log(`Cliente conectado: ${socket.id}`);
      socket.on("disconnect", () => {
        console.log(`Cliente desconectado: ${socket.id}`);
      });

      //Join to room.
      socket.on("join_room", (room: string) => {
        socket.join(room);
        console.log(`Usuario ${socket.id} se unió a la sala: ${room}`);
      });

      //Leave from room
      socket.on("leave-room", (room: string) => {
        socket.leave(room);
        console.log(`Cliente salió de la sala: ${room}`);
      });

      // Chat Module
      socket.on(
        "send_message",
        ({
          room,
          globalRoom,
          userId,
          message,
        }: {
          room: string;
          globalRoom: string;
          userId: string;
          message: any;
        }) => {
          this.chatModule.sendMessage(
            socket,
            room,
            globalRoom,
            userId,
            message
          );
        }
      );

      socket.on("broadcast_message", (message: any) => {
        this.chatModule.broadcastMessage(socket, message);
      });

      // get chat not seen
      socket.on("get_chat_not_seen", (auctionId: string) => {
        this.chatModule.getChatNotSeen(socket, auctionId);
      });

      // update chat seen
      socket.on("update_chat_seen", (room: string) => {
        this.chatModule.updateChatSeen(room);
      });

      // get chat by room
      socket.on(
        "get_chat_by_room",
        ({ room, auctionId }: { room: string; auctionId: string }) => {
          this.chatModule.getChatByRoom(socket, room, auctionId);
        }
      );

      // send alert by user
      socket.on("send_alert_by_user", (data: any) => {
        this.resumensModule.notifyAlertByUser(socket, data.userId, data);
      });

      socket.on("notify_auction_change", (data: any) => {
        try {
          const parsedData = typeof data === "string" ? JSON.parse(data) : data;
          this.auctionModule.notifyAuctionChange(this.io, parsedData.auctionId, parsedData.changeData);
        } catch (error) {
          console.error("Error al parsear los datos:", error);
        }
      });
      
      socket.on("notify_auction_offer", (data: any) => {
        try {
          const parsedData = typeof data === "string" ? JSON.parse(data) : data;
          this.auctionModule.notifyAuctionOfferChange(this.io, parsedData.auctionId, parsedData.changeData);
        } catch (error) {
          console.error("Error al parsear los datos:", error);
        }
      });

      socket.on("notify_users_auction_change", (data: any) => {
        const { users, changeData } = data;
        this.auctionModule.notifyUsersOfAuctionChange(
          this.io,
          users,
          changeData
        );
      });
    });
  };
}
