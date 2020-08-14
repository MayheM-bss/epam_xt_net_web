function charRemover(str) {
  var repeatedChars = fillArrayRepeatedChars(str);

  var unrepeatedChars = str.split("").filter((symbol) => {
    return repeatedChars.indexOf(symbol) == -1;
  });

  var result = unrepeatedChars.join("");
  console.log(result);
  return result;
}

function fillArrayRepeatedChars(str) {
  let ignoredChars = [" ", "\t", "?", "!", ":", ";", ",", "."];
  let words = str.split(" ");
  let repeated = [];
  words.forEach((word) => {
    for (let i = 0; i <= word.length; i++) {
      if (
        repeated.indexOf(word[i]) == -1 &&
        ignoredChars.indexOf(word[i]) == -1 &&
        word.indexOf(word[i]) != word.lastIndexOf(word[i])
      ) {
        repeated.push(word[i]);
      }
    }
  });

  return repeated;
}

charRemover("У попа была собака");
