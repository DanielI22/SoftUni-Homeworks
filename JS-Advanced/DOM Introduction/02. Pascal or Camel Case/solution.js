function solve() {
  let textToTransform = document.getElementById("text").value;
  let naming = document.getElementById("naming-convention").value;

  let result = document.getElementById("result");

  if(naming == "Camel Case") {
    result.textContent = toCamelCase(textToTransform);
  }
  else if(naming == "Pascal Case") {
    result.textContent = toPascalCase(textToTransform);
  }
  else {
    result.textContent = "Error!";
  }

  function toCamelCase(str) {
    str = str.toLowerCase();
    console.log(str);
    let array = str.split(' ');
    let result = array[0];
    for(let i = 1; i<array.length; i++) {
      result+=array[i].charAt(0).toUpperCase() + array[i].slice(1);
    }

    return result;
  }

  function toPascalCase(str) {
    str = str.toLowerCase();
    console.log(str);
    let array = str.split(' ');
    let result = "";
    for(let i = 0; i<array.length; i++) {
      result+=array[i].charAt(0).toUpperCase() + array[i].slice(1);
    }

    return result;
  }
}