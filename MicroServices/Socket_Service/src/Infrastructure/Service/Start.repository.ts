import cors from "@fastify/cors";
import * as dotenv from "dotenv";
import { FastifyInstance } from "fastify";
import path from "path";
import { ISocketRepository } from "../../Domain/Service/ISocket.repository";
import { IStartRepository } from "../../Domain/Service/IStart.repository";
import { loadRoutes } from "../Router";

export default class StartRepository implements IStartRepository {
  readonly app: FastifyInstance;
  readonly socket: ISocketRepository;

  constructor(App: FastifyInstance, Socket: ISocketRepository) {
    this.app = App;
    this.socket = Socket;
    this.configureEnvironment();
    this.configureMiddlewares();
  }
  public configureEnvironment = (): void => {
    const envFile =
      process.env.NODE_ENV !== "production" ? `.env.local` : ".env";
    dotenv.config({ path: path.join(__dirname, `../${envFile}`) });
  };
  public configureMiddlewares = (): void => {
    this.app.register(cors, {
      origin: process.env.CORS_ORIGIN ?? "*",
      methods: ["GET", "POST", "PUT", "DELETE"],
    });
    this.app.addHook("onRequest", (req, reply, done) => {
      reply.startTime = Date.now();
      req.log.info(
        `📥 [Request Received] | Method: ${req.method} | URL: ${req.raw.url} | IP: ${req.ip}`
      );
      done();
    });

    this.app.addHook("onResponse", (req, reply, done) => {
      const duration = Date.now() - reply.startTime;
      req.log.info(
        `📤 [Request Completed] | Method: ${req.method} | URL: ${req.raw.url} | Duration: ${duration}ms`
      );
      done();
    });
  };

  public configureRoutes = async (): Promise<void> => {
    await loadRoutes(this.app); // Carga de rutas
  };

  public start = async (): Promise<void> => {
    try {
      await this.configureRoutes();
      const port = Number(process.env.PORT ?? 9087);
      this.app.listen({ port, host: "0.0.0.0" }, (err) => {
        if (err) {
          this.app.log.error(err);
          process.exit(1);
        }
      });
      this.app.ready().then(() => {
        const appIo = this.app as any;
        this.socket.initialize(appIo.io);
      });
    } catch (err) {
      this.app.log.error(err);
      process.exit(1);
    }
  };
}
