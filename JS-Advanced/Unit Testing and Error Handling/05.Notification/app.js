function notify(message) {
  let div = document.getElementById('notification');
  div.style.display = 'block';
  div.textContent = message;
  div.addEventListener('click', () => {
    div.style.display = 'none';
  });
}