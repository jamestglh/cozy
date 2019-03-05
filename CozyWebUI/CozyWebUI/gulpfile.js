const sass = require('gulp-sass');
const gulp = require('gulp');
const concat = require('gulp-concat');
const cssmin = require('gulp-cssmin');

sass.compiler = require('node-sass');

function sassTask() {
    return gulp.src('./wwwroot/sass/**/*.scss')
        .pipe(sass().on('error', sass.logError))
        .pipe(concat('style.css'))
        .pipe(cssmin())
        .pipe(gulp.dest('./wwwroot/css'));
}

function sassWatch() {
    gulp.watch('./wwwroot/sass/**/*.scss', gulp.series([sassTask]))
}

exports.css = sassTask;
exports.cssWatch = sassWatch;

exports.default = exports.css;