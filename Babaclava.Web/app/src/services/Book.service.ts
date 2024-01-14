import axios, { AxiosResponse } from "axios"
import { IBook } from "../types/Book";

export const BookService = {
  async getPage(bookId: string, countOfSigns: number, pageNumber: number): Promise<IBook[]> {
    try {
      const response: AxiosResponse<IBook[]> = await axios.get(`http://localhost:5145/api/v1/book/${bookId}`, {
        params: {
          bookId,
          countOfSigns,
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
      const response: AxiosResponse<IBook[]> = await axios.get(`http://localhost:5145/api/v1/save-progress`, {
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