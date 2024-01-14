import React, { useState, useEffect } from "react";
import styles from "./styles.module.css";

const printedTextStyle = {
  color: "rgba(0, 0, 0, 0.2)",
};

const activeLetterStyle = {
  color: "black",

  border: "solid 0.1px",
};

const reference =
  "Кто бы ты ни был, мой читатель, на каком бы месте ни стоял, в каком бы звании ни находился, почтен ли ты высшим чином или человек простого сословия, но если тебя вразумил Бог грамоте и попалась уже тебе в руки моя книга, я прошу тебя помочь мне.В книге, которая перед тобой, которую, вероятно, ты уже прочел в ее первом издании, изображен человек, взятый из нашего же государства. Ездит он по нашей Русской земле, встречается с людьми всяких сословий, от благородных до простых. Взят он больше затем, чтобы показать недостатки и пороки русского человека, а не его достоинства и добродетели, и все люди, которые окружают его, взяты также затем, чтобы показать наши слабости и недостатки; лучшие люди и характеры будут в других частях. В книге этой многое описано неверно, не так, как есть и как действительно происходит в Русской земле, потому что я не мог узнать всего: мало жизни человека на то, чтобы узнать одному и сотую часть того, что делается в нашей земле. Притом от моей собственной оплошности, незрелости и поспешности произошло множество всяких ошибок и промахов, так что на всякой странице есть что поправить: я прошу тебя, читатель, поправить меня. Не пренебреги таким делом. Какого бы ни был ты сам высокого образования и жизни высокой, и какою бы ничтожною ни показалась в глазах твоих моя книга, и каким бы ни показалось тебе мелким делом ее исправлять и писать на нее замечания, — я прошу тебя это сделать. А ты, читатель невысокого образования и простого звания, не считай себя таким невежею, чтобы ты не мог меня чему-нибудь поучить. Всякий человек, кто жил и видел свет и встречался с людьми, заметил что-нибудь такое, чего другой не заметил, и узнал что-нибудь такое, чего другие не знают. А потому не лиши меня твоих замечаний: не может быть, чтобы ты не нашелся чего-нибудь сказать на какое-нибудь место во всей книге, если только внимательно прочтешь ее.";
const TypeBook: React.FC = () => {
  const countOfSigns = 1035;
  const text = reference.slice(0, countOfSigns);
  const [typedText, setTypedText] = useState<string>("");

  const handleKeyPress = (event: React.KeyboardEvent<HTMLDivElement>) => {
    const pressedKey = event.key;

    if (/^.$/.test(pressedKey)) {
      if (text[typedText.length] === pressedKey) {
        setTypedText(typedText + pressedKey);
        console.log(typedText);
      }
    }
  };

  useEffect(() => {
    const handleKeyDown = (event: KeyboardEvent) => {
      handleKeyPress(event as any);
    };

    document.addEventListener("keydown", handleKeyDown);

    return () => {
      document.removeEventListener("keydown", handleKeyDown);
    };
  }, [handleKeyPress]);

  return (
    <div className={styles.container}>
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

      <h2 className="text-2xl font-bold text-white mt-3 ">2/378</h2>
    </div>
  );
};

export default TypeBook;
