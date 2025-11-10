export class ConfigMssqlDto {
  public user: string;
  public password: string;
  public server: string;
  public database: string;
  public port: number;

  constructor(
    user: string,
    password: string,
    server: string,
    database: string,
    port: number
  ) {
    this.user = user;
    this.password = password;
    this.server = server;
    this.database = database;
    this.port = port;
  }
}
