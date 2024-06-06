import { BaseClient } from '../base-client'
import { ApplicationLogs } from './types/application-logs'
import { GetAllLogsParams } from './types/get-all-logs-params'

export class ApplicationLogsClient extends BaseClient {
  async getAll(
    params: GetAllLogsParams,
    signal?: AbortSignal
  ): Promise<ApplicationLogs> {
    return (await this.axios.get('/api/application-logs', { params, signal })).data
  }
}
