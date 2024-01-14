export interface IBook {
    id: string
    title: string
    author: string
    image: string
    pageSize: string
    pageNumber: number
    totalPages: number
}

export interface IPage {
  text: string
  pageSize: number
  hasNextPage: boolean
  hasPreviousPage: boolean
}