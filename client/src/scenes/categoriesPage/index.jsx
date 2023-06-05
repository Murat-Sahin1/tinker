import NavBar from "scenes/navbar";
import { useState, useEffect } from "react";
import { Box, Typography, useTheme } from "@mui/material";
import CategoryListingButton from "widgets/categoryWidgets/CategoryListingButton";
import ProductListingWidget from "widgets/categoryWidgets/ProductListingWidget";
import FlexBetween from "components/FlexBetween";
import axios from "axios";
import { useNavigate, useLocation } from "react-router-dom";

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

  const navigate = useNavigate();
  const location = useLocation();

  const [products, setProducts] = useState([]);
  const [choosenCategory, setChoosenCategory] = useState(2);

  useEffect(() => {
    setChoosenCategory(location.state)
    console.log('Location state changed:', location.state);
  }, [location]);

  useEffect(() => {
    axios
      .get(`https://localhost:7260/api/Category/wproducts/${choosenCategory}`)
      .then((response) => {
        setProducts(response.data.products);
        console.log(response.data);
      })
      .catch((error) => {
        console.log(error);
      });
  }, [choosenCategory]);

  const handleCategoryChange = (categoryId) => {
    setChoosenCategory(categoryId);
  };

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
            <CategoryListingButton
              onClick={() => handleCategoryChange(1)}
              categoryName={"Reinforcement Learning"}
            />
            <CategoryListingButton
              onClick={() => handleCategoryChange(2)}
              categoryName={"Computer Vision"}
            />
            <CategoryListingButton
              onClick={() => handleCategoryChange(3)}
              categoryName={"Language Processing"}
            />
            <CategoryListingButton
              onClick={() => handleCategoryChange(4)}
              categoryName={"Medical Imaging"}
            />
            <CategoryListingButton
              onClick={() => handleCategoryChange(5)}
              categoryName={"Game AI"}
            />
            <CategoryListingButton
              onClick={() => handleCategoryChange(6)}
              categoryName={"Customer Segmentation"}
            />
            <CategoryListingButton
              onClick={() => handleCategoryChange(7)}
              categoryName={"Others"}
            />
          </Box>
        </Box>
        <Box flexBasis="85%" display="flex" gap="1.5rem" paddingLeft="1.5rem">
          {products.map((product, index) => (
            <ProductListingWidget
              key = {index}
              onClick={()=>{navigate("/productDetail", {state: {product}})}}
              name={product.name}
              description={product.description}
              price = {product.price}
            ></ProductListingWidget>
          ))}
        </Box>
      </Box>
    </Box>
  );
};

export default CategoriesPage;
