import { useContext } from 'react'
import { ApiClientContext } from '../contexts/api-client-context'

export function useClient () {
  return useContext(ApiClientContext)
}
