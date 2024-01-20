import { useEffect, useState } from "react";
import styles from "./styles.module.css";
import { BookService } from "../../../../services/Book.service";
import { BookCard } from "../../../BookCard/BookCard";

interface IBook {
  author: string;
  bookId: string;
  pageNumber: number;
  pageSize: number;
  title: string;
  totalPages: number;
}

export const MyBooks = () => {
  const [books, setBooks] = useState<IBook[] | null>(null);

  useEffect(() => {
    const getBooks = async () => {
      try {
        const books = await BookService.getCatalog(12);
        setBooks(books);
        console.log(books   );
      } catch (error) {
        console.error("Ошибка запроса:", error);
      }
    };

    getBooks();
  }, []);

  if (books)
    return (
      <div className={styles.container}>
        {books.map((book) => (
          <BookCard book={book} />
        ))}
      </div>
    );
};
