import {
  render as testingLibraryRender,
  RenderOptions as TestingLibraryRenderOptions,
  RenderResult
} from '@testing-library/react'
import { ApiClient } from '@/client'
import { ReactElement } from 'react'
import { MemoryRouter } from 'react-router-dom'
import { ApiClientProvider } from '../components/ApiClientProvider'

type RenderOptions = Omit<TestingLibraryRenderOptions, 'queries'> & {
  client?: ApiClient
}

export function render (
  ui: ReactElement,
  options: RenderOptions = {}
): RenderResult {
  const {
    client = new ApiClient({ baseURL: 'no requests should be made in tests' }),
    ...testingLibraryOptions
  } = options

  return testingLibraryRender(
    <MemoryRouter>
      <ApiClientProvider client={client}>
        {ui}
      </ApiClientProvider>
    </MemoryRouter>,
    testingLibraryOptions
  )
}
