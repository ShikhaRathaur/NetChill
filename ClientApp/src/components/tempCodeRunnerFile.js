let text = window.location.href;
  const video_names_array = text.split("/");
  let len = video_names_array.length;
  this.index = video_names_array[len - 1];
  const val = parseInt(this.index);