export const colorTokens = {
    grey: {
      0: "#FFFFFF",
      10: "#F6F6F6",
      50: "#f0e6de",
      100: "#e5d7c4",
      200: "#d5c5a3",
      300: "#b3a176",
      400: "#88714a",
      500: "#5e4821",
      600: "#443215",
      700: "#37281a",
      800: "#291e11",
      900: "#1c140b",
      1000: "#0e0906",
    },
    primary: {
      50: "#EEE2C3",
      100: "#E6D9B6 ",
      200: "#D9CCA9",
      300: "#CCBF9B",
      400: "#BEB28E",
      500: "#A59575",
      600: "#8B7A5C",
      700: "#725F44",
      800: "#5E4A34",
      900: "#4C3A27 ",
    },
  };
  
  // material ui theme settings
  export const themeSettings = (mode) => {
    return {
      palette: {
        mode: mode,
        ...(mode === "dark"
          ? {
              //palette values for dark mode
              primary: {
                dark: colorTokens.primary[200],
                main: colorTokens.primary[500],
                light: colorTokens.primary[800],
              },
              neutral: {
                dark: colorTokens.grey[100],
                main: colorTokens.grey[200],
                mediumMain: colorTokens.grey[300],
                medium: colorTokens.grey[400],
                light: colorTokens.grey[700],
              },
              background: {
                default: colorTokens.grey[900],
                alt: colorTokens.grey[800],
              },
            }
          : {
              //palette values for light mode
              primary: {
                dark: colorTokens.primary[700],
                main: colorTokens.primary[500],
                light: colorTokens.primary[50],
              },
              neutral: {
                dark: colorTokens.grey[700],
                main: colorTokens.grey[500],
                mediumMain: colorTokens.grey[400],
                medium: colorTokens.grey[300],
                light: colorTokens.grey[50],
              },
              background: {
                default: colorTokens.grey[10],
                alt: colorTokens.grey[0],
              },
            }),
      },
      typography: {
          fontFamily: ['Aleo', "serif"].join(","),
          fontSize: 12,
          h1:{
              fontFamily: ['Aleo', "serif"].join(","),
              fontSize: 40,
          },
          h2:{
              fontFamily: ["Aleo", "serif"].join(","),
              fontSize: 32,
          },
          h3:{
              fontFamily: ["Aleo", "serif"].join(","),
              fontSize: 24,
          },
          h4:{
              fontFamily: ["Aleo", "serif"].join(","),
              fontSize: 20,
          },
          h5:{
              fontFamily: ["Aleo", "serif"].join(","),
              fontSize: 16,
          },
          h6:{
              fontFamily: ["Aleo", "serif"].join(","),
              fontSize: 14,
          }
      }
    };
  };
  