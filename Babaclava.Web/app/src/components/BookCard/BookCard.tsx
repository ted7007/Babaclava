import { IBook } from "../../types/Book";
import styles from "./styles.module.css";
import bookCover from "../../assets/bookCover.jpg";

export const BookCard = ({ book }: { book: IBook }) => {
  return (
    <div className={styles.container}>
      <img src={bookCover} alt="" />
      <p>title</p>
      <p className={styles.author}>author</p>
    </div>
  );
};
