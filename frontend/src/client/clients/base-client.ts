import { AxiosInstance } from 'axios'

export type BaseClientOptions = {
  axios: AxiosInstance
  baseURL: string
}

export abstract class BaseClient {
  protected axios: AxiosInstance
  protected baseURL: string

  constructor (options: BaseClientOptions) {
    this.axios = options.axios
    this.baseURL = options.baseURL
  }
}
