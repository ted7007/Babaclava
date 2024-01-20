import { MyBooks } from "./MyBooks/MyBooks";
import styles from "./styles.module.css";

export const Catalog = () => {
  return (
    <div className={styles.container}>
      <MyBooks />
    </div>
  );
};
