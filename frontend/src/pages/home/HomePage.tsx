import { useAtom } from 'jotai'
import { countAtom } from '@/utils/atoms'
import { Button, Flex } from '@mantine/core';

export function HomePage() {
  const [count, setCount] = useAtom(countAtom)

  const handleAdd = () => {
    setCount(count => count + 1)
  }

  const handleRemove = () => {
    setCount(count => count - 1)
  }

  return (
    <>
      <h1>Home Page</h1>
      <Flex
        align='center'
        justify='center'
        direction='column'
      >
        <h4>{count}</h4>
        <Flex
          gap='sm'
        >
          <Button onClick={handleAdd} variant='light'>Add</Button>
          <Button onClick={handleRemove} variant='outline' color='red'>Remove</Button>
        </Flex>
      </Flex>
    </>
  )
}
