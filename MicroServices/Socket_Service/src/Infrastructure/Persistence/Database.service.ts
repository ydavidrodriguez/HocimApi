import * as mssql from "mssql";
import { ConfigMssqlDto } from "./config/config-mssql.dto";

export class DatabaseService {
  private pool: mssql.ConnectionPool;
  constructor(private readonly credentials: ConfigMssqlDto) {
    const config: mssql.config = {
      user: credentials.user,
      password: credentials.password,
      server: credentials.server,
      database: credentials.database,
      port: credentials.port,
      options: {
        encrypt: false, // true para Azure; false para bases de datos locales
        trustServerCertificate: true, // solo si es necesario
      },
    };

    // Inicializar la conexión de forma sincrónica
    this.pool = new mssql.ConnectionPool(config);
    this.pool
      .connect()
      .then(() => {
        console.log("MSSQL CONNECTED!");
      })
      .catch((err) => {
        console.error("Error al conectar con la base de datos:", err);
        throw err;
      });
  }

  public async query(query: string): Promise<any> {
    return "result";
  }

  public async SaveMessageChat(
    auctionId: string,
    userId: string,
    message: string,
    room: string
  ): Promise<any> {
    try {
      const request = this.pool.request();
      request.input("SubastaId", mssql.UniqueIdentifier, auctionId);
      request.input("UsuarioId", mssql.UniqueIdentifier, userId);
      request.input("Mensajes", mssql.VarChar(500), message);
      request.input("Visto", mssql.Bit, 0);
      request.input("Sala", mssql.VarChar(50), room);
      const result = await request.execute("POSTMESSAGECREATEAUCTION");
      return result.recordset;
    } catch (err) {
      console.error(
        "Error ejecutando el procedimiento almacenado POSTMESSAGECREATEAUCTION:",
        err
      );
      throw err;
    }
  }

  public async getChatNotSeen(
    auctionId: string
  ): Promise<{ idRoom: string; isNew: boolean }[]> {
    try {
      const request = this.pool.request();
      request.input("SubastaId", mssql.UniqueIdentifier, auctionId);

      const query = `
        SELECT 
            Sala AS idRoom,
            CASE 
                WHEN EXISTS (
                    SELECT 1 
                    FROM Mensaje 
                    WHERE Sala = m.Sala AND SubastaId = @SubastaId AND visto = 0
                ) THEN CAST(1 AS BIT)
                ELSE CAST(0 AS BIT)
            END AS isNew
        FROM Mensaje m
        WHERE SubastaId = @SubastaId
        GROUP BY Sala;
      `;

      const result = await request.query(query);
      return result.recordset;
    } catch (err) {
      console.error(
        "Error ejecutando la consulta para obtener salas por subasta:",
        err
      );
      throw err;
    }
  }

  public async updateChatSeen(room: string) {
    try {
      const request = this.pool.request();
      request.input("Sala", mssql.VarChar(50), room);

      const query = `
        UPDATE Mensaje
        SET Visto = 1
        WHERE Sala = @Sala;
      `;

      const result = await request.query(query);
      return result.recordset;
    } catch (error) {
      console.error(
        "Error ejecutando el procedimiento almacenado UPDATECHATSEEN:",
        error
      );
      throw error;
    }
  }

  public async getChatByRoom(room: string, auctionId: string): Promise<any> {
    try {
      const request = this.pool.request();
      request.input("Sala", mssql.VarChar(50), room);
      request.input("SubastaId", mssql.UniqueIdentifier, auctionId);
      const result = await request.query(
        "SELECT * FROM Mensaje WHERE Sala = @Sala AND SubastaId = @SubastaId ORDER BY FechaCreacion ASC"
      );
      return result.recordset;
    } catch (error) {
      console.error(
        "Error ejecutando la consulta para obtener el chat por sala:",
        error
      );
      throw error;
    }
  }

  public async saveRound({
    round,
    time,
    auctionId,
  }: {
    round: number;
    time: number;
    auctionId: string;
  }): Promise<any> {
    try {
      const request = this.pool.request();
      request.input("SubastaId", mssql.UniqueIdentifier, auctionId);
      request.input("Round", mssql.Int, round);
      request.input("Tiempo", mssql.Int, time);
      request.output("IdRonda", mssql.UniqueIdentifier);
      const result = await request.execute("POSTCREATERONDAAUCTION");
      return result.output.IdRonda;
    } catch (error) {
      console.error(
        "Error ejecutando el procedimiento almacenado POSTCREATERONDAAUCTION:",
        error
      );
      throw error;
    }
  }

  public async saveItems(items: any[], roundId: string): Promise<any> {
    try {
      for (const item of items) {
        const request = this.pool.request();
        request.input("Nombre", mssql.VarChar(100), item.nombre);
        request.input("Cantidad", mssql.Int, item.cantidad);
        request.input("valorUnidad", mssql.Int, item.valorUnidad);
        request.input("NuevaOferta", mssql.Float, item.newOffer);
        request.input("RondaId", mssql.UniqueIdentifier, roundId);
        request.input("ItemId", mssql.UniqueIdentifier, item.idItem);
        await request.execute("POSTCREATERONDAITEMSAUCTION");
      }
    } catch (error) {
      console.error(
        "Error ejecutando el procedimiento almacenado POSTCREATEITEMSAUCTION:",
        error
      );
      throw error;
    }
  }

  public async saveUsers(users: any[], roundId: string): Promise<any> {
    try {
      for (const user of users) {
        const request = this.pool.request();
        request.input("UsuarioId", mssql.UniqueIdentifier, user.usuarioId);
        request.input("RondaId", mssql.UniqueIdentifier, roundId);
        await request.execute("POSTCREATERONDAUSERAUCTION");
      }
    } catch (error) {
      console.error(
        "Error ejecutando el procedimiento almacenado POSTCREATEUSERSAUCTION:",
        error
      );
      throw error;
    }
  }

  public async getRoundActive(auctionId: string, now: Date): Promise<any> {
    const query = `
            SELECT 
                IdRonda, 
                SubastaId, 
                FechaCreacion, 
                Tiempo, 
                ROUND,
                DATEADD(MINUTE, Tiempo, FechaCreacion) AS FechaFinal
            FROM Ronda
            WHERE SubastaId = @SubastaId
            AND DATEADD(MINUTE, Tiempo, FechaCreacion) > @CurrentTime
            ORDER BY FechaFinal ASC
        `;

    const request = this.pool.request();
    request.input("SubastaId", mssql.UniqueIdentifier, auctionId);
    request.input("CurrentTime", mssql.DateTime, now);
    const result = await request.query(query);
    return result.recordset[0];
  }

  public async getRoundActiveHolandesa(auctionId: string, now: Date): Promise<any> {
    const query = `
            SELECT 
                IdRonda, 
                SubastaId, 
                FechaCreacion, 
                Tiempo, 
                ROUND,
                DATEADD(MINUTE, Tiempo, FechaCreacion) AS FechaFinal
            FROM Ronda
            WHERE SubastaId = @SubastaId
            AND DATEADD(MINUTE, Tiempo, FechaCreacion) > @CurrentTime
            ORDER BY FechaFinal ASC
        `;

    const request = this.pool.request();
    request.input("SubastaId", mssql.UniqueIdentifier, auctionId);
    request.input("CurrentTime", mssql.DateTime, now);
    const result = await request.query(query);
    return result.recordset[0];
  }



  public async haveRoundActive(auctionId: string, now: Date): Promise<any> {
    const query = `
            SELECT TOP 1 1 
            FROM Ronda
            WHERE SubastaId = @SubastaId
            AND DATEADD(MINUTE, Tiempo, FechaCreacion) > @CurrentTime
        `;

    const request = this.pool.request();
    request.input("SubastaId", mssql.UniqueIdentifier, auctionId);
    request.input("CurrentTime", mssql.DateTime, now);
    const result = await request.query(query);
    return result.recordset.length > 0;
  }

  public async getLatestRound(auctionId: string): Promise<any> {
    const query = `
            WITH LastRonda AS (
            SELECT TOP 1 *
            FROM Ronda
            WHERE SubastaId = @IdSubasta
            ORDER BY FechaCreacion DESC
            )
            SELECT 
                r.IdRonda,
                r.SubastaId,
                r.FechaCreacion,
                r.Tiempo,
                r.Round,
                i.IdItemsRonda,
                i.ItemId,
                i.Nombre,
                i.Cantidad,
                i.valorUnidad,
                i.NuevaOferta
            FROM LastRonda r
            LEFT JOIN ItemsRonda i ON r.IdRonda = i.RondaId;
            `;

    const request = this.pool.request();
    request.input("SubastaId", mssql.UniqueIdentifier, auctionId);
    const result = await request.query(query);
    return result.recordset;
  }

  public async getRoundActiveByUserHolandesa(
    auctionId: string,
    userId?: string|null
  ): Promise<any> {

    const request = this.pool.request();
    request.input("IdSubasta", mssql.UniqueIdentifier, auctionId);
     // Si userId es null o undefined, se pasa como NULL explícito
    if (userId) {
      request.input("IdUsuario", mssql.UniqueIdentifier, userId);
    } else {
      request.input("IdUsuario", mssql.UniqueIdentifier, null);
    }
    const result = await request.execute("GETUCTIONITEMHOLANDESA");
    return result.recordset;
  }

  public async getRoundActiveByUser(
    auctionId: string,
    userId: string,
    now: Date
  ): Promise<any> {
    const query = `
      SELECT
        r.IdRonda,
        r.SubastaId,
        r.FechaCreacion,
        r.Tiempo,
        DATEADD(MINUTE, r.Tiempo, r.FechaCreacion) AS FechaFinal,
        ir.IdItemsRonda,
        ir.Nombre,
        ir.Cantidad,
        ir.NuevaOferta,
        ir.ItemId
      FROM
        Ronda r
        INNER JOIN UsuarioRonda ur ON ur.RondaId = r.IdRonda
        INNER JOIN ItemsRonda ir ON ir.RondaId = r.IdRonda
      WHERE
        r.SubastaId = @SubastaId
        AND ur.UsuarioId = @UserId
        AND DATEADD(MINUTE, r.Tiempo, r.FechaCreacion) > @CurrentTime
      ORDER BY
        FechaFinal ASC
    `;

    const request = this.pool.request();
    request.input("SubastaId", mssql.UniqueIdentifier, auctionId);
    request.input("UserId", mssql.UniqueIdentifier, userId);
    request.input("CurrentTime", mssql.DateTime, now);
    const result = await request.query(query);
    return result.recordset;
  }

  public async userIsVoted(roundId: string, userId: string): Promise<any> {
    const query = `SELECT * FROM RespuestaRonda WHERE RondaId = @RondaId AND UsuarioRondaId = @UserId`;
    const request = this.pool.request();
    request.input("RondaId", mssql.UniqueIdentifier, roundId);
    request.input("UserId", mssql.UniqueIdentifier, userId);
    const result = await request.query(query);
    return result.recordset.length > 0;
  }

  public async saveResponseRound(
    items: {
      roundId: string;
      itemId: string;
      userId: string;
      response: string;
    }[]
  ): Promise<any> {
    try {
      for (const item of items) {
        const { roundId, itemId, userId, response } = item;
        const request = this.pool.request();
        request.input("ITEMRONDAID", mssql.UniqueIdentifier, itemId);
        request.input("USUARIORONDAID", mssql.UniqueIdentifier, userId);
        request.input("RONDAID", mssql.UniqueIdentifier, roundId);
        request.input("RESPUESTARONDA", mssql.VarChar(2), response);
        await request.execute("CREATERESPONSERONDA");
      }
    } catch (error) {
      console.error(
        "Error ejecutando el procedimiento almacenado CREATERESPONSERONDA:",
        error
      );
      throw error;
    }
  }

  public async saveItemsRoundHolandesa(items: any[], roundId: string): Promise<any> {
    try {
      for (const item of items) {
        const request = this.pool.request();
        request.input("ItemId", mssql.UniqueIdentifier, item.idItem);
        request.input("PrecioInicial", mssql.Int, item.valorInicial);
        request.input("DescuentoAumento", mssql.Int, item.descuentoAumento);
        request.input("LimiteOferta", mssql.Int, item.limiteOferta);
        request.input("Oferta", mssql.Int, item.oferta);
        request.input("RondaId", mssql.UniqueIdentifier, roundId);
        await request.execute("POSTCREATEAUCTIONITEMHOLANDESA");
      }
    } catch (error) {
      console.error(
        "Error ejecutando el procedimiento almacenado POSTCREATEAUCTIONITEMHOLANDESA:",
        error
      );
      throw error;
    }
  }

  public async getResponseByUser(userId: string, auctionId: string): Promise<any> {
    const query = `
      SELECT DISTINCT
        ur.*,
        ir.*,
        rr.respuesta,
        r.FechaCreacion
      FROM
        Ronda r
        INNER JOIN UsuarioRonda ur ON ur.RondaId = r.IdRonda
        INNER JOIN ItemsRonda ir ON ir.RondaId = r.IdRonda
        INNER JOIN RespuestaRonda rr ON rr.RondaId = ir.RondaId
        AND ir.ItemId = rr.ItemsRondaId
      WHERE
        rr.UsuarioRondaId = @UserId
        AND r.SubastaId = @SubastaId
        AND EXISTS (
          SELECT
            1
          FROM
            RespuestaRonda
          WHERE
            itemsRondaId = ir.ItemId
            AND UsuarioRondaId = @UserId
        )
      ORDER BY r.FechaCreacion ASC
    `;
    const request = this.pool.request();
    request.input("UserId", mssql.UniqueIdentifier, userId);
    request.input("SubastaId", mssql.UniqueIdentifier, auctionId);
    const result = await request.query(query);
    return result.recordset;
  }

  public async saveResponseRoundHolandesa(
    items: {
      roundId: string;
      itemId: string;
      userId: string;
      response: string;
    }[]
  ): Promise<any> {
    try {
      for (const item of items) {
        const { roundId, itemId, userId, response } = item;
        const request = this.pool.request();
        request.input("ITEMRONDAID", mssql.UniqueIdentifier, itemId);
        request.input("USUARIORONDAID", mssql.UniqueIdentifier, userId);
        request.input("RONDAID", mssql.UniqueIdentifier, roundId);
        request.input("RESPUESTARONDA", mssql.VarChar(2), response);
        await request.execute("CREATERESPONSERONDAHOLANDESA");
      }
    } catch (error) {
      console.error(
        "Error ejecutando el procedimiento almacenado CREATERESPONSERONDA:",
        error
      );
      throw error;
    }
  }

  public async saveResponseOtorgarJaponesa(
   body:any
  ): Promise<any> {
    try {
        const request = this.pool.request();
        request.input("IdItem", mssql.UniqueIdentifier, body.IdItem);
        request.input("IdRonda", mssql.UniqueIdentifier, body.IdRonda);
        request.input("IdUsuario", mssql.UniqueIdentifier, body.IdUsuario);
        await request.execute("POSTUCTIONGRANTITEMPROVIDERJAPONESA");
      
    } catch (error) {
      console.error(
        "Error ejecutando el procedimiento almacenado POSTUCTIONGRANTITEMPROVIDERJAPONESA:",
        error
      );
      throw error;
    }
  }

  public async getResponseItemByUserHolandesa(
    auctionId: string,
    userId: string, 
    filterGranted: boolean = false // false = No filtrar, true = Filtrar por Otorgado = 1
  ): Promise<any> {
    const request = this.pool.request();
    request.input("IdSubasta", mssql.UniqueIdentifier, auctionId);
    request.input("IdUsuario", mssql.UniqueIdentifier, userId);
    request.input("FiltrarOtorgado", mssql.Bit, filterGranted);
    const result = await request.execute("GETUCTIONRESPONSEITEMHOLANDESA");
    return result.recordset;
  }

  public async getResponseItemProviderHolandesa(
    auctionId: string,
    filterGranted: boolean = false // false = No filtrar, true = Filtrar por Otorgado = 1
  ): Promise<any> {
    const request = this.pool.request();
    request.input("IdSubasta", mssql.UniqueIdentifier, auctionId);
    request.input("FiltrarOtorgado", mssql.Bit, filterGranted);
    const result = await request.execute("GETUCTIONRESPONSEITEMPROVIDERHOLANDESA");
    return result.recordset;
  }

  public async getResponseItemProviderJaponesa(
    auctionId: string,
    filterGranted: boolean = false // false = No filtrar, true = Filtrar por Otorgado = 1
  ): Promise<any> {
    const request = this.pool.request();
    request.input("IdSubasta", mssql.UniqueIdentifier, auctionId);
    request.input("FiltrarOtorgado", mssql.Bit, filterGranted);
    const result = await request.execute("GETUCTIONRESPONSEITEMPROVIDERJAPONESA");
    return result.recordset;
  }

  public async getLatestRoundHolandesa(auctionId: string): Promise<any> {
    const request = this.pool.request();
    request.input("IdSubasta", mssql.UniqueIdentifier, auctionId);
    const result = await request.execute("GETLISTLASTSUBASTA");
    return result.recordset;
  }

  public async POSTUCTIONGRANTITEMBYUSERJAPONESA(IdItem: string ,IdRonda:string,IdUsuario:string): Promise<any> {
    const request = this.pool.request();
    request.input("IdItem", mssql.UniqueIdentifier, IdItem);
    request.input("IdRonda", mssql.UniqueIdentifier, IdRonda);
    request.input("IdUsuario", mssql.UniqueIdentifier, IdUsuario);
    const result = await request.execute("POSTUCTIONGRANTITEMBYUSERJAPONESA");
    return result.recordset;
  }

  public async getItemsCountByAuction(auctionId: string): Promise<number>{
    const query = `
      SELECT COUNT(*) AS Total
      FROM ItemSubasta 
      WHERE SubastaId = @AuctionId
    `;
    const request = this.pool.request();
    request.input("AuctionId", mssql.UniqueIdentifier, auctionId);
    const result = await request.query(query);
    return result.recordset[0].Total;
  }
}


