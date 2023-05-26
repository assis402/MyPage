# MyPage ![status](https://img.shields.io/static/v1?label=status&message=ready&color=blue)
Professional web page with ASP.NET (C#, HTML, CSS and Javascript).

This project was built in ASP.NET MVC and integrated with the Github API for displaying repositories and their information.

## Structure
```
└── Solution
    ├── Application             // Application layer (inluding business and integration)
    │   ├── Helpers             // Utility classes with specific goals
    │   ├── Integrations        // Integration with Githuh API
    │   ├── Models              // Model classes to pages
    │   └── Services            // Services with logics to get projects from github or cache in memory
    │    
    └── UI                      // User interface layer
        ├── wwwroot             // Static files (.css, .js and images)
        ├── Controllers         // Contains class files for the controllers (MVC pattner)
        ├── Resources           // Language resources (PT-BR and EN-US)
        ├── Views               // .cshtml files (pages)
        ├── appsettings.json    // Contains environment variables, log configuration...
        ├── bundleconfig.json   // Bundling configuration.
        ├── LanguageResource.cs // Empty class for language switcher operation. 
        └── Program.cs          // Application startup and configuration.
```

## To Do
- [x] About page.
- [x] Github integration.
- [x] Projects page.
- [x] Language switcher.
- [x] Bundling and Minification.
- [ ] Deploy at jenkins 
