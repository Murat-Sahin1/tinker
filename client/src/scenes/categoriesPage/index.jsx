import NavBar from "scenes/navbar";
import { useState, useEffect } from "react";
import { Box, Typography, useTheme } from "@mui/material";
import CategoryListingButton from "widgets/categoryWidgets/CategoryListingButton";
import FlexBetween from "components/FlexBetween";
import axios from "axios";

const CategoriesPage = () => {
  const theme = useTheme();
  const neutralMain = theme.palette.neutral.mediumMain;
  const neutral = theme.palette.neutral.light;
  const neutralDark = theme.palette.neutral.dark;
  const dark = theme.palette.neutral.dark;
  const background = theme.palette.background.default;
  const primaryLight = theme.palette.primary.light;
  const primaryMain = theme.palette.primary.main;
  const alt = theme.palette.background.alt;

  const [categories, setCategories] = useState([]);

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

  return (
    <Box>
      <NavBar />
      <Box
        width="100%"
        padding="2rem 4%"
        justifyContent={"center"}
        display="flex"
        gap="0.5rem"
        alignItems={"space-between"}
      >
        {/* CATEGORY LISTING */}
        <Box
          flexBasis="15%"
          alignSelf={"flex-start"}
          borderRadius={3}
          backgroundColor={alt}
          boxShadow={3}
        >
          <Box
            justifyContent={"center"}
            gap="1.5rem"
            alignItems="center"
            display="flex"
            flexDirection={"column"}
            marginY="1rem"
          >
            {categories.map((category) => (
              <CategoryListingButton 
                categoryName = {category.name}
              />
            ))}
          </Box>
        </Box>
        <Box flexBasis="85%" padding="20rem"></Box>
      </Box>
    </Box>
  );
};

export default CategoriesPage;
