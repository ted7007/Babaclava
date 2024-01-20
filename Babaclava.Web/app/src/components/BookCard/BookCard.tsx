import { IBook } from "../../types/Book";
import styles from "./styles.module.css";
import bookCover from "../../assets/bookCover.jpg";
import { Link } from "react-router-dom";

export const BookCard = ({ book }: { book: IBook }) => {
  return (
    <Link to={`/${book.bookId}/type`}>
      <div className={styles.container}>
        <img src={bookCover} alt="" />
        <p>{book.author}</p>
        <p className={styles.author}>{book.author}</p>
      </div>
    </Link>
  );
};
