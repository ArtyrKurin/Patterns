module.exports = function (grunt) {
    grunt.initConfig({
        concat: {
            build: {
                src: ['wwwroot/js/*'],
                dest: 'wwwroot/js/app.js'
            }
        },
        uglify: {
            build: {
                files: {
                    'wwwroot/bundles/jquery.js': ['wwwroot/lib/jquery/dist/jquery.js'],
                    'wwwroot/bundles/jqueryval.js': ['wwwroot/lib/jquery-validation/dist/jquery.validate.js', 'lib/jquery-validation-unobtrusive/jquery.validate.unobtrusive.js'],
                    'wwwroot/bundles/bootstrap.js': ['wwwroot/lib/bootstrap/dist/js/bootstrap.min.js'],
                    'wwwroot/bundles/app.js': ['wwwroot/js/app.js']
                }
            }
        },
        clean: ["wwwroot/js/app.js"],
        cssmin: {
            build: {
                files: {
                    'wwwroot/bundles/main.css': ['wwwroot/lib/bootstrap/dist/css/bootstrap.css', 'wwwroot/css/site.css']
                }
            }
        }
    });

    grunt.loadNpmTasks('grunt-contrib-cssmin');
    grunt.loadNpmTasks('grunt-contrib-concat');
    grunt.loadNpmTasks('grunt-contrib-uglify');
    grunt.loadNpmTasks('grunt-contrib-clean');

    grunt.registerTask('build', ['copy', 'concat', 'uglify', 'cssmin', 'clean']);
};