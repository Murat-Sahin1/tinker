import NavBar from "scenes/navbar";
import { useState } from "react";
import FlexBetween from "components/FlexBetween";
import Form from "./Form";
import { Box, Typography, useMediaQuery, useTheme } from "@mui/material";
import ModelOutput from "./ModelOutput";

const ModelLoadPage = () => {
  const theme = useTheme();
  const isNonMobileScreens = useMediaQuery("(min-width:1000px)");
  const alt = theme.palette.background.alt;

  const [modelName, setModelName] = useState("");

  const handleModelNameChange = (value) => {
    setModelName(value);
  };

  return (
    <Box>
      <NavBar />
      {/* MODEL NAME */}
      <Box>
        <Typography>
          {modelName}
        </Typography>
      </Box>


      {/* HOME PAGE */}
      <Box
        width="100%"
        padding="2rem 6%"
        display={isNonMobileScreens ? "flex" : "block"}
        gap="4rem"
        justifyContent="space-around"
      >
        {/* POSTS */}
        <Box
          flexBasis={isNonMobileScreens ? "40%" : undefined}
          mt={isNonMobileScreens ? undefined : "2rem"}
        >
          <Box
            width="100%"
            padding="1% 6%"
            justifyContent="center"
            textAlign={"center"}
            backgroundColor={alt}
            borderRadius={10}
          >
            <Form onValueChange={handleModelNameChange}></Form>
          </Box>
        </Box>
        {/* FRIENDS-LIST */}

        <Box flexBasis="50%">
          <Box
            width="100%"
            padding="1% 6%"
            justifyContent="center"
            textAlign={"center"}
            backgroundColor={alt}
            borderRadius={10}
          >
            <ModelOutput></ModelOutput>
          </Box>
        </Box>
      </Box>
    </Box>
  );
};

export default ModelLoadPage;
