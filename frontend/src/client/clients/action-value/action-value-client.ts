import { BaseClient } from '../base-client'
import { CreateActionValueCommand, ActionValueResult } from './types'

export class ActionValueClient extends BaseClient {

  async create(
    params: CreateActionValueCommand,
    signal?: AbortSignal
  ): Promise<ActionValueResult> {
    return (await this.axios.post('/action-values', params, { signal })).data
  }

}
