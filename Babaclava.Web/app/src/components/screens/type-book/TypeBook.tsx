import React, { useState, useEffect } from "react";
import styles from "./styles.module.css";
import { BookService } from "../../../services/Book.service";
import { COUNT_OF_SIGNS } from "../../../constants/book";
import { IPage } from "../../../types/Book";
import { Link } from "react-router-dom";

const printedTextStyle = {
  color: "rgba(0, 0, 0, 0.2)",
};

const activeLetterStyle = {
  color: "black",
  border: "solid 0.1px",
};

const TypeBook: React.FC = () => {
  const countOfSigns = COUNT_OF_SIGNS;

  const [text, setText] = useState<string | null>(null);
  const [bookId, setBookId] = useState<number | null>(null);
  const [pageNumber, setPageNumber] = useState<number>(0); // Изменил на 0, чтобы начать с первой страницы
  const [typedText, setTypedText] = useState<string>("");

  const handleKeyPress = (event: React.KeyboardEvent<HTMLDivElement>) => {
    if (!text) return;
    const pressedKey = event.key;

    if (/^.$/.test(pressedKey)) {
      if (text[typedText.length] === pressedKey) {
        setTypedText(typedText + pressedKey);
        console.log(typedText);
      }
    }
  };

  const handleNextPage = () => {
    setPageNumber(pageNumber + 1);
    setTypedText("");
  };

  const handlePrevPage = () => {
    if (pageNumber > 0) {
      setPageNumber(pageNumber - 1);
      setTypedText("");
    }
  };

  useEffect(() => {
    const fetchData = async () => {
      try {
        const response: IPage = await BookService.getPage(
          "dca6f3e2-aa7f-411c-b82f-7b8fbd715f9a",
          pageNumber
        );
        const { text } = response;
        setText(text);
      } catch (error) {
        console.error("Ошибка запроса:", error);
      }
    };

    fetchData();
  }, [pageNumber]);

  useEffect(() => {
    const handleKeyDown = (event: KeyboardEvent) => {
      if (event.key === "ArrowRight") {
        handleNextPage();
      } else if (event.key === "ArrowLeft") {
        handlePrevPage();
      } else {
        handleKeyPress(event as any);
      }
    };

    document.addEventListener("keydown", handleKeyDown);

    return () => {
      document.removeEventListener("keydown", handleKeyDown);
    };
  }, [handleKeyPress, handleNextPage, handlePrevPage]);

  useEffect(() => {
    if (!text || !pageNumber) return;
    if (typedText.length === text.length) {
      BookService.saveProgress(
        "dca6f3e2-aa7f-411c-b82f-7b8fbd715f9a",
        pageNumber
      );
      // Обновил запрос следующей страницы
      BookService.getPage(
        "dca6f3e2-aa7f-411c-b82f-7b8fbd715f9a",
        pageNumber + 1
      );
    }
  }, [typedText]);

  if (text)
    return (
      <div className={styles.container}>
        <div className={styles.title}>
          <Link to="/catalog">
            <div
              style={{
                display: "flex",
                gap: "1.5rem",
                alignItems: "center",
              }}
            >
              <h1 style={{ color: "white", paddingBottom: "1rem" }}>
                ← Книга 11
              </h1>
            </div>
          </Link>
        </div>
        <div className={styles.book}>
          <div className={styles.textcols}>
            {text.split("").map((char, index) => (
              <span
                key={index}
                style={
                  index < typedText.length
                    ? printedTextStyle
                    : index === typedText.length
                    ? activeLetterStyle
                    : {}
                }
              >
                {char}
              </span>
            ))}
          </div>
        </div>

        <h2 className="text-2xl font-bold text-white mt-3 ">
          {pageNumber + 1}/{countOfSigns}
        </h2>
      </div>
    );
};

export default TypeBook;
