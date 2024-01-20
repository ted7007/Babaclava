import styles from "./styles.module.css";

export const Header = () => {
  const links = [
    {
      title: "Статистика",
      href: "/",
    },
    {
      title: "Главная",
      href: "/",
    },
    {
      title: "Форум",
      href: "/",
    },
  ];

  return (
    <div className={styles.container}>
      <div className={styles.options}>
        <div className={styles.option}>Статистика</div>
        <div className={`${styles.option} ${styles.active}`}>Главная</div>
        <div className={styles.option}>Форум</div>
      </div>
    </div>
  );
};
