export interface IStartRepository {
  configureEnvironment(): void;
  configureMiddlewares(): void;
  configureRoutes(): void;
  start(): void;
}
