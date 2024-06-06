import { describe, expect, test } from 'vitest'
import { screen } from '@testing-library/react'
import { HomePage } from '.'
import { render } from '@/tests/render'

describe('HomePage', () => {
  describe('When page is render', () => {
    test('Should render HomePage title', () => {
      const title = 'Home Page'

      render(<HomePage />)

      expect(screen.getByText(title)).toBeDefined()
    })
  })
})
