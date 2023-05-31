import NavBar from "scenes/navbar";
import { useState, useEffect } from "react";
import FlexBetween from "components/FlexBetween";
import "./styles.css";
import {
  Box,
  Typography,
  Button,
  useMediaQuery,
  useTheme,
  Divider,
} from "@mui/material";
import { BorderColor, Landscape } from "@mui/icons-material";
import SellerButton from "widgets/SellerButton";
import ClassIcon from "@mui/icons-material/Class";
import CategoryButton from "widgets/CategoryButton";
import axios from "axios";
import { useNavigate } from "react-router-dom";

const HomePage = () => {
  const [categories, setCategories] = useState([]);

  const navigate = useNavigate();

  const isNonMobileScreens = useMediaQuery("(min-width:1000px)");
  const theme = useTheme();

  const dark = theme.palette.neutral.dark;
  const background = theme.palette.background.default;
  const primaryLight = theme.palette.primary.light;
  const primaryMain = theme.palette.primary.main;
  const alt = theme.palette.background.alt;

  useEffect(() => {
    axios
      .get("https://localhost:7260/api/Category")
      .then((response) => {
        setCategories(response.data);
        console.log(categories);
        console.log(response.data);
      })
      .catch((error) => {
        console.log(error);
      });
  }, []);

  const handleCategoryClick = () => {
    
  }

  return (
    <Box>
      <NavBar />
      {/* HOME PAGE */}
      <Box
        width="100%"
        padding="2rem"
        justifyContent="center"
        alignItems={"center"}
        alignSelf={"center"}
        display="flex"
        flexDirection={"column"}
      >
        {/* HEADER */}
        <Box
          margin="1rem"
          width={"77%"}
          borderRadius={2}
          gap="0.5rem"
          padding={"7%"}
          display="flex"
          flexDirection={"column"}
          backgroundColor={alt}
          sx={{
            backgroundImage:
              'url("https://artin2minutes.files.wordpress.com/2020/12/michelangelo_the-creation-of-adam_art_works_summary_art-in-2-minutes-e1609407812717.jpg")',
            backgroundSize: "cover",
          }}
          alignItems="center"
          justifyContent={"center"}
          alignSelf={"center"}
        >
          <Box
            marginTop="1rem"
            backgroundColor={dark}
            borderRadius={3}
            sx={{ backgroundSize: "cover", boxShadow: 5 }}
          >
            <Typography
              fontWeight="bold"
              margin="0.3rem"
              marginRight={"0.5rem"}
              marginLeft={"0.5rem"}
              variant="h6"
              color="primary"
            >
              Brand New
            </Typography>
          </Box>
          <Box
            paddingRight={1}
            paddingLeft={1}
            my="0.5rem"
            backgroundColor={primaryMain}
            borderRadius={2}
            sx={{ opacity: "0.9", boxShadow: 5 }}
          >
            <Typography
              fontWeight="bold"
              fontSize={"1rem"}
              alignItems={"center"}
              color={"white"}
              sx={{ opacity: "1 !important" }}
            >
              Artifical Intelligence, made for people.
            </Typography>
          </Box>
          <Box marginBottom={"1rem"}>
            <Button
              variant="contained"
              sx={{ boxShadow: 5 }}
              onClick={() => navigate(`/categories`)}
            >
              <Typography
                fontWeight="bold"
                sx={{ letterSpacing: 2 }}
                color={background}
              >
                Marketplace
              </Typography>
            </Button>
          </Box>
        </Box>
        {/* COFFEE MESSAGE */}
        {isNonMobileScreens && (
          <Box
            margin="1rem"
            paddingRight={"4rem"}
            paddingLeft={"4rem"}
            borderRadius={2}
            display="flex"
            flexDirection={"column"}
            alignItems="center"
            justifyContent={"center"}
            alignSelf={"center"}
            backgroundColor={alt}
            marginTop="3rem"
            marginBottom="3rem"
            boxShadow={10}
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
              <Typography fontSize={19}>
                <Box justifyContent={"center"}>
                  Want to deploy a project but need help?
                </Box>
                <Box justifyContent={"center"}>
                  Work with a proffesional fits your mind.
                </Box>
              </Typography>
            </Box>
          </Box>
        )}
      </Box>
      <Box
        marginX={isNonMobileScreens ? "13rem" : "0rem"}
        marginBottom="1rem"
        alignItems={"center"}
        justifyContent={"center"}
        alignSelf={"center"}
      >
        <Divider>
          <Typography fontSize={15}>Build the future with us.</Typography>
        </Divider>
      </Box>
      <Box
        justifyContent={"center"}
        alignContent={"center"}
        alignSelf={"center"}
        display={"flex"}
        marginTop="1.3rem"
      >
        <FlexBetween
          gap={"3rem"}
          flexDirection={isNonMobileScreens ? "row" : "column"}
        >
          <SellerButton image="https://media.npr.org/assets/img/2022/03/26/gettyimages-1205198865-336675718789d5e96b8a024f6f497c41418c4c93.jpg"></SellerButton>
          <SellerButton image="https://media.npr.org/assets/img/2022/03/26/gettyimages-1205198865-336675718789d5e96b8a024f6f497c41418c4c93.jpg"></SellerButton>
          <SellerButton image="https://media.npr.org/assets/img/2022/03/26/gettyimages-1205198865-336675718789d5e96b8a024f6f497c41418c4c93.jpg"></SellerButton>
          <SellerButton image="https://media.npr.org/assets/img/2022/03/26/gettyimages-1205198865-336675718789d5e96b8a024f6f497c41418c4c93.jpg"></SellerButton>
        </FlexBetween>
      </Box>
      <Box
        justifyContent={"center"}
        alignContent={"center"}
        alignSelf={"center"}
        minWidth={"50px"}
        display={"flex"}
        marginTop="1.3rem"
      >
        <FlexBetween
          gap={"3rem"}
          marginBottom={"3rem"}
          flexDirection={isNonMobileScreens ? "row" : "column"}
        >
          <SellerButton image="https://media.npr.org/assets/img/2022/03/26/gettyimages-1205198865-336675718789d5e96b8a024f6f497c41418c4c93.jpg"></SellerButton>
          <SellerButton image="https://media.npr.org/assets/img/2022/03/26/gettyimages-1205198865-336675718789d5e96b8a024f6f497c41418c4c93.jpg"></SellerButton>
          <SellerButton image="https://media.npr.org/assets/img/2022/03/26/gettyimages-1205198865-336675718789d5e96b8a024f6f497c41418c4c93.jpg"></SellerButton>
          <SellerButton image="https://media.npr.org/assets/img/2022/03/26/gettyimages-1205198865-336675718789d5e96b8a024f6f497c41418c4c93.jpg"></SellerButton>
        </FlexBetween>
      </Box>
      <Box padding="3rem" boxShadow={12}>
        <Box
          display="flex"
          backgroundColor={background}
          width="100%"
          sx={{ justifyContent: "space-around", alignItems: "center" }}
        >
          <Box
            height="100%"
            width="30%"
            display={"flex"}
            flexDirection={"column"}
            alignItems={"center"}
          >
            <Box
              width={"70%"}
              right={0}
              flexDirection={"column"}
              alignItems={"center"}
            >
              <ClassIcon style={{ fontSize: "2rem", color: dark }}></ClassIcon>
              <Typography
                fontSize={"1.5rem"}
                fontWeight={"bold"}
                color="primary"
              >
                Categories
              </Typography>
              <Typography variant="h6">
                Thousands of creators work as a community to solve Audio,
                Vision, and Language with AI.
              </Typography>
              <Typography variant="h6" fontWeight={"bold"} paddingTop="10px">
                See them all
              </Typography>
            </Box>
          </Box>
          <Box
            display="flex"
            padding="2rem"
            height="100%"
            width="90%"
            gap="1.2rem"
            marginRight={"4rem"}
            flexDirection={"row"}
          >
            {categories.map((category) => (
              <CategoryButton
                isClicked={(id)=>{navigate(`/categories`, { state: category.id})}}
                icon={"Image"}
                categoryName={category.name}
                modelCount={432}
              ></CategoryButton>
            ))}
          </Box>
        </Box>
      </Box>
    </Box>
  );
};

export default HomePage;
