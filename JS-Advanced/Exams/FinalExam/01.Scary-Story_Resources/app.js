window.addEventListener("load", solve);

function solve() {
  let firstName = document.getElementById("first-name");
  let lastName = document.getElementById("last-name");
  let age = document.getElementById("age");
  let storyTitle = document.getElementById("story-title");
  let genre = document.getElementById("genre");
  let yourStory = document.getElementById("story");
  let publishBtn = document.getElementById("form-btn");

  let previewList = document.getElementById('preview-list');
  publishBtn.addEventListener('click', (ev) => {
      ev.preventDefault();
      let sfName = firstName.value;
      let slName = lastName.value;
      let sAge = age.value;
      let sTitle = storyTitle.value;
      let sGenre = genre.value;
      let sStory = yourStory.value;

      if(sfName === "" || slName === "" || sAge === "" || sTitle === "" || sStory === ""){
        return;
      }

      let story = document.createElement('li');
      story.classList.add('story-info');

      story.innerHTML = `
      <article>
        <h4>Name: ${sfName} ${slName}</h4>
        <p>Age: ${sAge}</p>
        <p>Title: ${sTitle}</p>
        <p>Genre: ${sGenre}</p>
        <p>${sStory}</p>
      </article>
      <button class = "save-btn">Save Story</button>
      <button class = "edit-btn">Edit Story</button>
      <button class = "delete-btn">Delete Story</button>
      `

      previewList.appendChild(story);

      story.querySelectorAll('button')[0].addEventListener('click', function () { save() });
      story.querySelectorAll('button')[1].addEventListener('click', function (ev) { edit(ev, sfName, slName, sAge, sTitle, sGenre, sStory) });
      story.querySelectorAll('button')[2].addEventListener('click', function (ev) { deleteE(ev) });

      firstName.value = "";
      lastName.value = "";
      age.value = "";
      storyTitle.value = "";
      yourStory.value = "";
      publishBtn.disabled = true;

  })

  function edit(ev, sfName, slName, sAge, sTitle, sGenre, sStory) {
      let preview = ev.target.parentElement;

      firstName.value = sfName;
      lastName.value = slName;
      age.value = sAge;
      storyTitle.value = sTitle;
      genre.value = sGenre;
      yourStory.value = sStory;

      preview.querySelectorAll('button')[0].disabled = true;
      preview.querySelectorAll('button')[1].disabled = true;
      preview.querySelectorAll('button')[2].disabled = true;

      publishBtn.disabled = false;
      previewList.removeChild(preview)
  }

  function save() {
    let main = document.getElementById('main');
    main.innerHTML = '';
    let h1 = document.createElement("h1");
    h1.innerText = "Your scary story is saved!";
    mainDiv.appendChild(h1);
  }

  function deleteE(ev) {
    ev.target.parentElement.remove();
    publishBtn.disabled = false;
  }
}
