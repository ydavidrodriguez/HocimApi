import { readdirSync } from "fs";
import { FastifyInstance } from "fastify";

const PATH_ROUTES = __dirname;

function removeExtension(fileName: string) {
  return fileName.split(".").shift();
}

/**
 * Carga y registra las rutas en Fastify con un prefijo basado en el nombre del archivo
 * @param {FastifyInstance} app - Instancia de Fastify
 */
export async function loadRoutes(app: FastifyInstance) {
  const files = readdirSync(PATH_ROUTES).filter(
    (file) =>
      file !== "index.js" &&
      file !== "index.ts" &&
      (file.endsWith(".js") || file.endsWith(".ts"))
  );

  for (const file of files) {
    const name = removeExtension(file);
    const { default: routes } = await import(`./${file}`);

    routes.forEach((route: any) => {
      const url = `/api/${route.versionApi}/${name}${route.url}`;
      delete route.versionApi;
      app.route({
        ...route,
        url,
      });
    });
  }
}
