import axios from 'axios'
import { BaseClientOptions } from './clients/base-client'
import { ApplicationLogsClient } from './clients/application-logs/application-logs-client'

export type ApiClientOptions = {
  baseURL?: string
  onUnauthorized?: () => void
}

export class ApiClient {
  applicationLogs: ApplicationLogsClient

  constructor (options: ApiClientOptions = {}) {
    const baseURL = options.baseURL || 'https://localhost:5001'

    const baseClientOptions: BaseClientOptions = {
      baseURL,
      axios: axios.create({
        baseURL: options.baseURL,
        withCredentials: true
      })
    }

    axios.interceptors.response.use(
      response => response,
      error => {
        if (error.response.status === 401) {
          options.onUnauthorized?.()
        }

        return error
      }
    )

    this.applicationLogs = new ApplicationLogsClient(baseClientOptions)
  }
}
