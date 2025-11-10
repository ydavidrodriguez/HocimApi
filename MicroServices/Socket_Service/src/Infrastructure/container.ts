import * as dotenv from "dotenv";
import { ContainerBuilder } from "node-dependency-injection";
import path from "path";
import Fastify from "fastify";
import SocketRepository from "./Service/Socket.repository";
import StartRepository from "./Service/Start.repository";
import ChatModule from "./Service/Modules/Chat.module";
import { DatabaseService } from "./Persistence/Database.service";
import {makeRequest} from "../External/Service/SendHttpRespository"
import { ConfigMssqlDto } from "./Persistence/config/config-mssql.dto";
import { RoundRepository } from "./Repository/round.repository";
import RoundCtrl from "./Controllers/round.ctrl";
import { RoundModule } from "./Service/Modules/Round.module";
import ResumensModule from "./Service/Modules/Resumens.module";
import AuctionModule from "./Service/Modules/Auction.module";
import { RoundholandesaRepository } from "./Repository/roundholandesa.repository";
import{RoundInglesaRepository} from "./Repository/roundinglesa.repository"
import roundholandesactrl from "./Controllers/roundholandesa.ctrl";
import RoundInglesactlr from "./Controllers/RoundInglesa.ctrl"

const envFile = process.env.NODE_ENV !== "production" ? `.env.local` : ".env";
dotenv.config({ path: path.join(__dirname, `../../${envFile}`) });

const container = new ContainerBuilder();

// Configuration server with sockets
const app = Fastify({
  logger: {
    transport: {
      target: "pino-pretty",
      options: {
        colorize: true,
        translateTime: "SYS:standard",
        singleLine: true,
        ignore: "pid,hostname",
      },
    },
  },
  disableRequestLogging: true,
});

// Config Database
const configMssql = new ConfigMssqlDto(
  process.env.DB_USER!,
  process.env.DB_PASSWORD!,
  process.env.DB_SERVER!,
  process.env.DB_DATABASE!,
  parseInt(process.env.DB_PORT!)
);

// Database Service
container
  .register("database.service", DatabaseService)
  .addArgument(configMssql);
const databaseService = container.get("database.service");

// Chat Module
container.register("chat.module", ChatModule).addArgument(databaseService);
const chatModule = container.get("chat.module");

// Round Module
container.register("round.module", RoundModule);
const roundModule = container.get("round.module");

// Resumens Module
container.register("resumens.module", ResumensModule);
const resumensModule = container.get("resumens.module");

// Resumens Module
container.register("auction.module", AuctionModule);
const auctionModule = container.get("auction.module");

// Configuración del servicio de sockets
container
  .register("service.socket", SocketRepository)
  .addArgument(app)
  .addArgument(chatModule)
  .addArgument(roundModule)
  .addArgument(resumensModule)
  .addArgument(auctionModule);

// Intance services
const socketService = container.get("service.socket");

const urlGateway = process.env.URL_BASE

// Round Repository
container
  .register("repository.round", RoundRepository)
  .addArgument(socketService)
  .addArgument(databaseService);
const roundRepository = container.get("repository.round");

// Round Controller
container.register("ctrl.round", RoundCtrl).addArgument(roundRepository);


// Round Repository
container
  .register("repository.roundholandesa", RoundholandesaRepository)
  .addArgument(socketService)
  .addArgument(databaseService);
const roundholandesaRepository = container.get("repository.roundholandesa");
// Round Holandesa Controller
container.register("ctrl.roundholandesa", roundholandesactrl).addArgument(roundholandesaRepository);

//Round Inglesa Controller
const epAddTime = urlGateway + process.env.EP_ADD_SUBASTA! 
const epCreateOftter = urlGateway + process.env.EP_ADD_OFFTER!
const epsSuspenderOftter = urlGateway + process.env.EP_SUSPE_AUCTION!
const epsSuspenderActivate = urlGateway + process.env.EP_ACTIVATE_AUCTION!
const epsEndActivate = urlGateway + process.env.EP_END_AUCTION!
container
  .register("repository.roundinglesa",RoundInglesaRepository)
  .addArgument(socketService)
  .addArgument(epAddTime)
  .addArgument(epCreateOftter)
  .addArgument(epsSuspenderOftter)
  .addArgument(epsSuspenderActivate)
  .addArgument(epsEndActivate);

const roundInglesaRepository = container.get("repository.roundinglesa");
container.register("ctrl.roundinglesa", RoundInglesactlr).addArgument(roundInglesaRepository);


// Service Start App
container
  .register("start.app", StartRepository)
  .addArgument(app)
  .addArgument(socketService);

export { app };
export default container;
