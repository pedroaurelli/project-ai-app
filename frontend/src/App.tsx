import { RouterProvider } from 'react-router-dom'
import { router } from './router'
import { ApiClientProvider } from './components/ApiClientProvider'
import { MantineProvider } from '@mantine/core';
import '@mantine/core/styles.css';

function App() {
  return (
    <MantineProvider>
      <ApiClientProvider>
        <RouterProvider router={router}/>
      </ApiClientProvider>
    </MantineProvider>
  )
}

export default App
