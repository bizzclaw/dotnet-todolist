let gulp = require('gulp');
let sass = require("gulp-sass");

gulp.task("sass", function() {
  return gulp.src('Styles/master.scss')
    .pipe(sass())
    .pipe(gulp.dest('./wwwroot/css'));
});