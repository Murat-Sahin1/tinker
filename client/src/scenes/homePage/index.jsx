import NavBar from "scenes/navbar";
import { Box, Typography, useMediaQuery, useTheme } from "@mui/material";

const HomePage = () => {
  const isNonMobileScreens = useMediaQuery("(min-width:1000px)");
  const theme = useTheme();
  const neutralLight = theme.palette.neutral.light;
  const dark = theme.palette.neutral.dark;
  const background = theme.palette.background.default;
  const primaryLight = theme.palette.primary.light;
  const primaryMain = theme.palette.primary.main;
  const alt = theme.palette.background.alt;

  return (
    <Box>
      <NavBar />
      {/* HOME PAGE */}
      <Box
        width="100%"
        padding="2rem"
        gap="0.5rem"
        justifyContent="center"
        alignItems={"center"}
        display="flex"
      >
        {/* MAIN MESSAGE */}
        <Box
          flexBasis={isNonMobileScreens ? "100%" : undefined}
          margin="1rem"
          maxWidth="50rem"
          borderWidth="2px"
          borderStyle="solid"
          borderColor = "red"
          borderRadius={2}
          display="flex"
          flexDirection={"column"}
          backgroundColor = {alt}
          alignItems="center"
          justifyContent={"center"}
          alignSelf={"center"}
        >
          <Typography
            fontWeight="bold"
            marginTop="1rem"
            variant="h1"
            color="primary"
            sx={{
              lineHeight: 1.2,
              whiteSpace: "pre-line",
            }}
          >
            <Box
              fontSize="5rem"
              margin="0.5rem"
              display={"flex"}
              justifyContent={"center"}
            >
              ☕
            </Box>
            <Box display={"flex"} justifyContent={"center"}>
              The high end AI models,
            </Box>
            <Box display={"flex"} justifyContent={"center"}>
              done by people you trust.
            </Box>
          </Typography>
          <Box marginTop={"1rem"} maxWidth={"4 rem"} marginBottom="1rem">
            <Typography fontSize={19} >
              <Box justifyContent={"center"}>
                Want to deploy a project but need help?
              </Box>
              <Box justifyContent={"center"}>
                Work with a proffesional fits your mind.
              </Box>
            </Typography>
          </Box>
        </Box>
      </Box>
    </Box>
  );
};

export default HomePage;
