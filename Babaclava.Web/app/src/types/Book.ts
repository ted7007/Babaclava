export interface IBook {
    bookId: string
    title: string
    author: string
    pageSize: number
    pageNumber: number
    totalPages: number
}

export interface IPage {
  text: string
  pageSize: number
  hasNextPage: boolean
  hasPreviousPage: boolean
}