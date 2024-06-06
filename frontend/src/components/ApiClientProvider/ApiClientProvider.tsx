import { ReactNode, useState } from 'react'
import { ApiClientContext } from '../../contexts/api-client-context'
import { ApiClient } from '@/client'

export type ApiClientProviderProps = {
  client?: ApiClient | null
  children: ReactNode
}

const baseURL = import.meta.env.VITE_API_BASE_URL as string

export function ApiClientProvider (props: ApiClientProviderProps) {
  const [client] = useState(props.client || new ApiClient({ baseURL }))

  return (
    <ApiClientContext.Provider value={client}>
      {props.children}
    </ApiClientContext.Provider>
  )
}
