import { createContext } from 'react'
import { ApiClient } from '../client'

export const ApiClientContext = createContext<ApiClient>(null!)
