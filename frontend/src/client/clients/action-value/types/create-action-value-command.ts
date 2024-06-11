import { ActionEnum } from './action-enum'

export type CreateActionValueCommand = {
  audioTranscriptionId: string
  action: ActionEnum
  value: number
  unitCategory: string
}
