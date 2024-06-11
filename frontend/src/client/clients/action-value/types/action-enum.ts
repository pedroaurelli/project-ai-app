export const actions = [
  'Eat',
  'Jump',
  'Run',
  'Walk',
] as const

export type ActionEnum = typeof actions[number]
