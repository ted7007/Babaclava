import axios, { AxiosResponse } from "axios"
import { IBook, IPage } from "../types/Book";

export const BookService = {
  async getPage(bookId: string, pageSize: number, pageNumber: number): Promise<IPage> {
    try {
      const response: AxiosResponse<IPage> = await axios.get(`http://localhost:5139/api/v1/book/page`, {
        params: {
          bookId,
          pageSize,
          pageNumber
        },
      });
      return response.data;
    } catch (error) {
      throw error;
    }
  },

  async saveProgress(bookId: string, pageSize: number, pageNumber: number) {
    try {
      const response: AxiosResponse<IPage> = await axios.get(`http://localhost:5139/api/v1/save-progress`, {
        params: {
          bookId,
          pageSize,
          pageNumber
        },
      });
      return response.data;
    } catch (error) {
      throw error;
    }
  }
};