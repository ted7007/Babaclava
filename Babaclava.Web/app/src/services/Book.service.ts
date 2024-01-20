import axios, { AxiosResponse } from "axios"
import { IBook, IPage } from "../types/Book";
import { COUNT_OF_SIGNS } from "../constants/book";

export const BookService = {
  async getPage(bookId: string, pageNumber: number): Promise<IPage> {
    try {
      const response: AxiosResponse<IPage> = await axios.get(`http://localhost:5139/api/v1/book/page`, {
        params: {
          bookId,
          pageSize: COUNT_OF_SIGNS,
          pageNumber
        },
      });
      return response.data;
    } catch (error) {
      throw error;
    }
  },

  async saveProgress(bookId: string, pageNumber: number) {
    try {
      const response: AxiosResponse = await axios.get(`http://localhost:5139/api/v1/save-progress`, {
        params: {
          bookId,
          pageSize: COUNT_OF_SIGNS,
          pageNumber
        },
      });
      return response.data;
    } catch (error) {
      throw error;
    }
  },

 async getCatalog(count: number) {
    try {
      const response: AxiosResponse = await axios.get(`http://localhost:5139/api/v1/catalog`, {
        params: {
          count,
          pageSize: COUNT_OF_SIGNS,
        },
      });
      return response.data;
    } catch (error) {
      throw error;
    }
  }
};