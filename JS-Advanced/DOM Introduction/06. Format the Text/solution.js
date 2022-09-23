function solve() {
  let textArea = document.getElementById("input").value;
  let sentences = textArea.split(".").filter(sen => sen.length > 0);

  let output = document.getElementById("output");
  for(let i = 0; i < sentences.length; i = i+3) {
    let text = sentences[i];
    if(!(typeof sentences[i+1] === 'undefined')) {
      text+=". "+sentences[i+1];
    }
    if(!(typeof sentences[i+2] === 'undefined')) {
      text+=". "+sentences[i+2];
    }
    text+=".";
    output.innerHTML += `<p>${text}</p>`;
  }
}