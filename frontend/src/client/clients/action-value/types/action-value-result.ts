import { ActionEnum } from './action-enum'

export type ActionValueResult = {
  id: string
  audioTranscriptionId: string
  action: ActionEnum
  value: number
  unitCategory: string
}
