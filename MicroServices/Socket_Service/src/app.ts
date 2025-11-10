/// <reference path="./types.d.ts" />
import container from "./Infrastructure/container";
import StartRepository from "./Infrastructure/Service/Start.repository";

const appConfig: StartRepository = container.get("start.app");
appConfig.start();

