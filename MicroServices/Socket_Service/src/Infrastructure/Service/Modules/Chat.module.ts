import { Socket } from "socket.io";
import { DatabaseService } from "../../Persistence/Database.service";
export default class ChatModule {
  private databaseService: DatabaseService;
  constructor(databaseService: DatabaseService) {
    this.databaseService = databaseService;
  }

  public sendMessage = (
    socket: Socket,
    room: string,
    globalRoom: string,
    userId: string,
    message: any
  ) => {
    socket.to(room).emit("receive_message", { sender: socket.id, message });
    socket.to(globalRoom).emit("new_message", { userId });
    console.log(
      `Mensaje enviado a la sala ${room}: ${JSON.stringify(message)}`
    );
    this.databaseService.SaveMessageChat(
      globalRoom,
      userId,
      message.message,
      room
    );
  };

  public broadcastMessage = (socket: Socket, message: any) => {
    const rooms = message.rooms;
    const text = message.message;
    const userId = message.userId;
    const globalRoom = message.globalRoom;
    rooms.forEach((room: any) => {
      socket
        .to(room.usuarioId)
        .emit("receive_message", { sender: socket.id, message: text });
      socket.to(globalRoom).emit("new_message", { userId });
      this.databaseService.SaveMessageChat(
        globalRoom,
        userId,
        text,
        room.usuarioId
      );
      console.log(
        `Mensaje global en la sala ${room}: ${JSON.stringify(message)}.`
      );
    });
  };

  public async getChatNotSeen(socket: Socket, auctionId: string) {
    const rooms = await this.databaseService.getChatNotSeen(auctionId);
    socket.emit("chat_not_seen", rooms);
  }

  public async getChatByRoom(socket: Socket, room: string, auctionId: string) {
    const chat = await this.databaseService.getChatByRoom(room, auctionId);
    socket.emit("chat_by_room", {
      chat,
      room,
    });
  }

  public async updateChatSeen(room: string) {
    await this.databaseService.updateChatSeen(room);
  }
}
